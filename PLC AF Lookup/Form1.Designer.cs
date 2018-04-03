namespace PLC_AF_Lookup
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plcSelectCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.histTxb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.webapiTxb = new System.Windows.Forms.TextBox();
            this.listPLCsBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.basicRBtn = new System.Windows.Forms.RadioButton();
            this.kerberosRBtn = new System.Windows.Forms.RadioButton();
            this.TagNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plcCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrumenttagCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afPathCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerfEqTagCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExDescCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // plcSelectCb
            // 
            this.plcSelectCb.FormattingEnabled = true;
            this.plcSelectCb.Location = new System.Drawing.Point(24, 102);
            this.plcSelectCb.Name = "plcSelectCb";
            this.plcSelectCb.Size = new System.Drawing.Size(188, 24);
            this.plcSelectCb.TabIndex = 0;
            this.plcSelectCb.SelectedIndexChanged += new System.EventHandler(this.plcSelectCb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select PLC";
            // 
            // histTxb
            // 
            this.histTxb.Location = new System.Drawing.Point(269, 39);
            this.histTxb.Name = "histTxb";
            this.histTxb.Size = new System.Drawing.Size(188, 22);
            this.histTxb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter Historian";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Enter Web API Server";
            // 
            // webapiTxb
            // 
            this.webapiTxb.Location = new System.Drawing.Point(513, 39);
            this.webapiTxb.Name = "webapiTxb";
            this.webapiTxb.Size = new System.Drawing.Size(188, 22);
            this.webapiTxb.TabIndex = 6;
            // 
            // listPLCsBtn
            // 
            this.listPLCsBtn.Location = new System.Drawing.Point(727, 19);
            this.listPLCsBtn.Name = "listPLCsBtn";
            this.listPLCsBtn.Size = new System.Drawing.Size(142, 42);
            this.listPLCsBtn.TabIndex = 8;
            this.listPLCsBtn.Text = "Generate PLC List";
            this.listPLCsBtn.UseVisualStyleBackColor = true;
            this.listPLCsBtn.Click += new System.EventHandler(this.listPLCsBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TagNameCol,
            this.plcCol,
            this.instrumenttagCol,
            this.afPathCol,
            this.PerfEqTagCol,
            this.ExDescCol});
            this.dataGridView1.Location = new System.Drawing.Point(24, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1697, 404);
            this.dataGridView1.TabIndex = 10;
            // 
            // basicRBtn
            // 
            this.basicRBtn.AutoSize = true;
            this.basicRBtn.Location = new System.Drawing.Point(24, 12);
            this.basicRBtn.Name = "basicRBtn";
            this.basicRBtn.Size = new System.Drawing.Size(63, 21);
            this.basicRBtn.TabIndex = 11;
            this.basicRBtn.TabStop = true;
            this.basicRBtn.Text = "Basic";
            this.basicRBtn.UseVisualStyleBackColor = true;
            // 
            // kerberosRBtn
            // 
            this.kerberosRBtn.AutoSize = true;
            this.kerberosRBtn.Location = new System.Drawing.Point(24, 46);
            this.kerberosRBtn.Name = "kerberosRBtn";
            this.kerberosRBtn.Size = new System.Drawing.Size(87, 21);
            this.kerberosRBtn.TabIndex = 12;
            this.kerberosRBtn.TabStop = true;
            this.kerberosRBtn.Text = "Kerberos";
            this.kerberosRBtn.UseVisualStyleBackColor = true;
            // 
            // TagNameCol
            // 
            this.TagNameCol.HeaderText = "TagName";
            this.TagNameCol.Name = "TagNameCol";
            this.TagNameCol.Width = 200;
            // 
            // plcCol
            // 
            this.plcCol.HeaderText = "PLC";
            this.plcCol.Name = "plcCol";
            this.plcCol.Width = 150;
            // 
            // instrumenttagCol
            // 
            this.instrumenttagCol.HeaderText = "Instrumenttag";
            this.instrumenttagCol.Name = "instrumenttagCol";
            this.instrumenttagCol.Width = 250;
            // 
            // afPathCol
            // 
            this.afPathCol.HeaderText = "AFPath";
            this.afPathCol.Name = "afPathCol";
            this.afPathCol.Width = 500;
            // 
            // PerfEqTagCol
            // 
            this.PerfEqTagCol.HeaderText = "PerfEqTag";
            this.PerfEqTagCol.Name = "PerfEqTagCol";
            this.PerfEqTagCol.Width = 300;
            // 
            // ExDescCol
            // 
            this.ExDescCol.HeaderText = "ExDesc";
            this.ExDescCol.Name = "ExDescCol";
            this.ExDescCol.Width = 250;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 600);
            this.Controls.Add(this.kerberosRBtn);
            this.Controls.Add(this.basicRBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listPLCsBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.webapiTxb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.histTxb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plcSelectCb);
            this.Name = "Form1";
            this.Text = "PLC AF Lookup";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox plcSelectCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox histTxb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox webapiTxb;
        private System.Windows.Forms.Button listPLCsBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton basicRBtn;
        private System.Windows.Forms.RadioButton kerberosRBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn plcCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumenttagCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn afPathCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerfEqTagCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExDescCol;
    }
}

