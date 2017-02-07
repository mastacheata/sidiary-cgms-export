namespace sinCsSample
{
    partial class frmAddIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddIn));
            this.cmdSendData = new System.Windows.Forms.Button();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.chkHypo = new System.Windows.Forms.CheckBox();
            this.txtCarb = new System.Windows.Forms.TextBox();
            this.lblCarbs = new System.Windows.Forms.Label();
            this.txtBG = new System.Windows.Forms.TextBox();
            this.lblBG = new System.Windows.Forms.Label();
            this.ApplicationTitle = new System.Windows.Forms.Label();
            this.picDummy = new System.Windows.Forms.PictureBox();
            this.MainLayoutPanel.SuspendLayout();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDummy)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSendData
            // 
            this.cmdSendData.Location = new System.Drawing.Point(107, 80);
            this.cmdSendData.Name = "cmdSendData";
            this.cmdSendData.Size = new System.Drawing.Size(75, 23);
            this.cmdSendData.TabIndex = 4;
            this.cmdSendData.Text = "Send Data";
            this.cmdSendData.UseVisualStyleBackColor = true;
            this.cmdSendData.Click += new System.EventHandler(this.cmdSendData_Click);
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainLayoutPanel.BackgroundImage")));
            this.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainLayoutPanel.ColumnCount = 2;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.MainLayoutPanel.Controls.Add(this.lstEvents, 1, 0);
            this.MainLayoutPanel.Controls.Add(this.pnl, 1, 1);
            this.MainLayoutPanel.Controls.Add(this.ApplicationTitle, 0, 1);
            this.MainLayoutPanel.Controls.Add(this.picDummy, 0, 0);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 2;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(498, 305);
            this.MainLayoutPanel.TabIndex = 1;
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.Location = new System.Drawing.Point(246, 3);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(244, 108);
            this.lstEvents.TabIndex = 2;
            // 
            // pnl
            // 
            this.pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl.BackColor = System.Drawing.Color.White;
            this.pnl.Controls.Add(this.chkHypo);
            this.pnl.Controls.Add(this.cmdSendData);
            this.pnl.Controls.Add(this.txtCarb);
            this.pnl.Controls.Add(this.lblCarbs);
            this.pnl.Controls.Add(this.txtBG);
            this.pnl.Controls.Add(this.lblBG);
            this.pnl.Location = new System.Drawing.Point(246, 127);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(249, 175);
            this.pnl.TabIndex = 3;
            // 
            // chkHypo
            // 
            this.chkHypo.AutoSize = true;
            this.chkHypo.Location = new System.Drawing.Point(193, 12);
            this.chkHypo.Name = "chkHypo";
            this.chkHypo.Size = new System.Drawing.Size(51, 17);
            this.chkHypo.TabIndex = 5;
            this.chkHypo.Text = "Hypo";
            this.chkHypo.UseVisualStyleBackColor = true;
            // 
            // txtCarb
            // 
            this.txtCarb.Location = new System.Drawing.Point(144, 35);
            this.txtCarb.MaxLength = 3;
            this.txtCarb.Name = "txtCarb";
            this.txtCarb.Size = new System.Drawing.Size(38, 20);
            this.txtCarb.TabIndex = 3;
            // 
            // lblCarbs
            // 
            this.lblCarbs.AutoSize = true;
            this.lblCarbs.Location = new System.Drawing.Point(12, 38);
            this.lblCarbs.Name = "lblCarbs";
            this.lblCarbs.Size = new System.Drawing.Size(76, 13);
            this.lblCarbs.TabIndex = 2;
            this.lblCarbs.Text = "Carbs in grams";
            // 
            // txtBG
            // 
            this.txtBG.Location = new System.Drawing.Point(144, 9);
            this.txtBG.MaxLength = 3;
            this.txtBG.Name = "txtBG";
            this.txtBG.Size = new System.Drawing.Size(38, 20);
            this.txtBG.TabIndex = 1;
            // 
            // lblBG
            // 
            this.lblBG.AutoSize = true;
            this.lblBG.Location = new System.Drawing.Point(12, 12);
            this.lblBG.Name = "lblBG";
            this.lblBG.Size = new System.Drawing.Size(115, 13);
            this.lblBG.TabIndex = 0;
            this.lblBG.Text = "Blood glucose in mg/dl";
            // 
            // ApplicationTitle
            // 
            this.ApplicationTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ApplicationTitle.BackColor = System.Drawing.Color.Transparent;
            this.ApplicationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationTitle.ForeColor = System.Drawing.Color.Fuchsia;
            this.ApplicationTitle.Location = new System.Drawing.Point(3, 171);
            this.ApplicationTitle.Name = "ApplicationTitle";
            this.ApplicationTitle.Size = new System.Drawing.Size(237, 86);
            this.ApplicationTitle.TabIndex = 0;
            this.ApplicationTitle.Text = "SampleAddIn Project for SiDiary6 created with Ms C# 2008 Express Edition";
            // 
            // picDummy
            // 
            this.picDummy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picDummy.Image = ((System.Drawing.Image)(resources.GetObject("picDummy.Image")));
            this.picDummy.Location = new System.Drawing.Point(3, 3);
            this.picDummy.Name = "picDummy";
            this.picDummy.Size = new System.Drawing.Size(237, 118);
            this.picDummy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDummy.TabIndex = 4;
            this.picDummy.TabStop = false;
            this.picDummy.Visible = false;
            // 
            // frmAddIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 305);
            this.Controls.Add(this.MainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddIn";
            this.MainLayoutPanel.ResumeLayout(false);
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDummy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdSendData;
        internal System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        internal System.Windows.Forms.ListBox lstEvents;
        internal System.Windows.Forms.Panel pnl;
        internal System.Windows.Forms.CheckBox chkHypo;
        internal System.Windows.Forms.TextBox txtCarb;
        internal System.Windows.Forms.Label lblCarbs;
        internal System.Windows.Forms.TextBox txtBG;
        internal System.Windows.Forms.Label lblBG;
        internal System.Windows.Forms.Label ApplicationTitle;
        internal System.Windows.Forms.PictureBox picDummy;
    }
}

