using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace PLC_AF_Lookup
{
    public partial class Form1 : Form
    {
        private PIWebAPIClient client;
        private List<string> plcList;
        private List<PIPoint> piPointList;

        public Form1()
        {
            InitializeComponent();
            histTxb.Text = "vmpisrv1";
            webapiTxb.Text = "vmpisrv1";
        }
        

        private void listPLCsBtn_Click(object sender, EventArgs e)
        {
            if ((histTxb.Text != "") && (webapiTxb.Text != ""))
            {
                try
                {
                    client = new PIWebAPIClient(kerberosRBtn.Checked);
                    getPIPoints();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void plcSelectCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string plc = plcSelectCb.SelectedItem.ToString();
                //search for PI points from selected plc
                List<PIPoint> selectPoints = piPointList.Where(x => x.plc == plc).ToList();
                //search AF config strings
                dataGridView1.Rows.Clear();
                selectPoints.AddRange(await getPerfEqPoints(selectPoints));
                getAFAttributes(selectPoints);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void getPIPoints()
        {
            //find webIDs of PI Points
            List<JObject> pointsObjList = new List<JObject>();
            string nextUrl;
            string lastUrl;
            string currentUrl;
            File.Delete(Directory.GetCurrentDirectory() + @"\FTLDPoints.txt");
            string url = "https://" + webapiTxb.Text + "/piwebapi/search/query?q=pointsource%3AFTLD&fields=name%3Bwebid&scope=pi%3A"
                + histTxb.Text + "&count=1000&start=0";
            //loop through multiple pages; max is 1000 per page
            do
            {
                JObject pointsObj = await client.GetAsync(url);
                currentUrl = url;
                nextUrl = pointsObj["Links"]["Next"].ToString();
                url = nextUrl;
                lastUrl = pointsObj["Links"]["Last"].ToString();
                pointsObjList.Add(pointsObj);
                File.AppendAllText(Directory.GetCurrentDirectory() + @"\FTLDPoints.txt", pointsObj.ToString());
            } while (currentUrl != lastUrl);
            piPointList = new List<PIPoint>();
            //build batch request
            url = "https://" + webapiTxb.Text + "/piwebapi/batch";
            string request = "{";
            foreach (JObject pointsObj in pointsObjList)
            {
                foreach (JObject obj in pointsObj["Items"])
                {
                    PIPoint newPoint = new PIPoint();
                    newPoint.name = obj["Name"].ToString();
                    newPoint.webid = obj["WebId"].ToString();
                    piPointList.Add(newPoint);
                    request += "\"" + obj["Name"] + "\":{\"Method\":\"GET\",\"Resource\":\"https://"
                        + webapiTxb.Text + "/piwebapi/points/" + obj["WebId"]
                        + "/attributes/instrumenttag?selectedfields=value\"},";
                }
            }
            request += "}";
            JObject instrumenttagsObj = await client.PostAsync(url, request);
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\Instrumenttags.txt", instrumenttagsObj.ToString());
            //parse instrumenttag for PLC
            plcList = new List<string>();
            foreach (PIPoint p in piPointList)
            {
                p.instrumenttag = instrumenttagsObj[p.name]["Content"]["Value"].ToString();
                Regex plcReg = new Regex(@".*?\[(.*?)].*");
                p.plc = plcReg.Replace(p.instrumenttag, "$1");
                plcList.Add(p.plc);
            }
            //populate combo box
            plcSelectCb.Items.AddRange(plcList.Distinct().ToArray());
            MessageBox.Show("Select your PLC from the drop down menu");
        }
        
        private async Task<List<PIPoint>> getPerfEqPoints(List<PIPoint> selectedPoints)
        {
            List<PIPoint> additions = new List<PIPoint>();
            //build batch search request to find performance equations
            string url = "https://" + webapiTxb.Text + "/piwebapi/batch";
            string request = "{";
            foreach (PIPoint p in selectedPoints)
            {
                request += "\"" + p.name + "\":{\"Method\":\"GET\",\"Resource\":\"https://"
                    + webapiTxb.Text + "/piwebapi/search/query?q=pointsource:C AND exdesc:*'" + p.name
                    + "'*&count=100&fields=name;webid\"},";
            }
            request += "}";
            JObject perfEqObj = await client.PostAsync(url, request);
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\perfEqSearch.txt", perfEqObj.ToString());
            //loop through response
            request = "{";
            foreach (PIPoint p in selectedPoints)
            {
                p.perfEq = "";
                foreach (JObject perfObj in perfEqObj[p.name]["Content"]["Items"])
                {
                    //add performance equation point to selected points array
                    PIPoint pePoint = new PIPoint();
                    pePoint.name = perfObj["Name"].ToString();
                    pePoint.webid = perfObj["WebId"].ToString();
                    //reference performance equation point on PLC point
                    p.perfEq += "'" + pePoint.name + "'";
                    //verify we haven't already added perf eq point in case it references multiple pi points
                    if (additions.Where(x => x.name == pePoint.name).ToList().Count == 0)
                    {
                        //build performance equation point request to get ExDesc
                        additions.Add(pePoint);
                        request += "\"" + pePoint.name + "\":{\"Method\":\"GET\",\"Resource\":\"https://"
                        + webapiTxb.Text + "/piwebapi/points/" + pePoint.webid
                        + "/attributes/exdesc?selectedfields=value\"},";
                    }
                }
            }
            request += "}";
            JObject exDescObj = await client.PostAsync(url, request);
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\perfEqExDesc.txt", exDescObj.ToString());
            //loop through response
            foreach (PIPoint pe in additions)
            {
                pe.exDesc = exDescObj[pe.name]["Content"]["Value"].ToString();
            }
            return additions;
        }

        private async void getAFAttributes(List<PIPoint> selectedPoints)
        {
            //build batch search request
            string url = "https://" + webapiTxb.Text + "/piwebapi/batch";
            string request = "{";
            foreach (PIPoint p in selectedPoints)
            {
                request += "\"" + p.name + "\":{\"Method\":\"GET\",\"Resource\":\"https://"
                    + webapiTxb.Text + "/piwebapi/search/query?q=attributevalue:" + p.name
                    + "&count=100&fields=paths;name;attributes\"},";
            }
            request += "}";
            JObject attribsObj = await client.PostAsync(url, request);
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\AFAttributes.txt", attribsObj.ToString());
            //loop through response
            foreach(PIPoint p in selectedPoints)
            {
                if (attribsObj[p.name]["Content"]["Items"].Count() > 0)
                {
                    //each element that has an attribute the pi point is tied to
                    foreach (JObject element in attribsObj[p.name]["Content"]["Items"])
                    {
                        //multiple af paths (e.g. element references)
                        JToken[] afPaths = element["Paths"].ToArray();
                        //pi point tied to more than one attribute in same element
                        List<JToken> matchedAttrib = element["Attributes"].
                            Where(x => String.Compare(x["Value"].ToString(), p.name, true) == 0).ToList();
                        foreach (JToken path in afPaths)
                        {
                            foreach (JToken attrib in matchedAttrib)
                            {
                                dataGridView1.Rows.Add(new object[]
                                    { p.name, p.plc, p.instrumenttag, path + @"|" + attrib["Name"], p.perfEq, p.exDesc });
                            }
                        }

                    }
                }
                else //pi point is not in AF
                    dataGridView1.Rows.Add(new object[] { p.name, p.plc, p.instrumenttag, "", p.perfEq, p.exDesc });
            }
        }
    }
}
