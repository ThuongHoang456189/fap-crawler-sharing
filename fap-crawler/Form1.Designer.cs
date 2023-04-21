namespace fap_crawler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblProcessStatus = new Label();
            btnCrawlData = new Button();
            txtSeedLink = new TextBox();
            label4 = new Label();
            lblLoginStatus = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblProcessStatus);
            panel1.Controls.Add(btnCrawlData);
            panel1.Controls.Add(txtSeedLink);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblLoginStatus);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(347, 359);
            panel1.TabIndex = 0;
            // 
            // lblProcessStatus
            // 
            lblProcessStatus.AutoSize = true;
            lblProcessStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblProcessStatus.Location = new Point(22, 292);
            lblProcessStatus.Name = "lblProcessStatus";
            lblProcessStatus.Size = new Size(66, 21);
            lblProcessStatus.TabIndex = 7;
            lblProcessStatus.Text = "Not yet!";
            // 
            // btnCrawlData
            // 
            btnCrawlData.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCrawlData.Location = new Point(123, 207);
            btnCrawlData.Name = "btnCrawlData";
            btnCrawlData.Size = new Size(113, 32);
            btnCrawlData.TabIndex = 6;
            btnCrawlData.Text = "Crawl Data";
            btnCrawlData.UseVisualStyleBackColor = true;
            btnCrawlData.Click += btnCrawlData_Click;
            // 
            // txtSeedLink
            // 
            txtSeedLink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSeedLink.Location = new Point(105, 152);
            txtSeedLink.Name = "txtSeedLink";
            txtSeedLink.Size = new Size(224, 29);
            txtSeedLink.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(22, 160);
            label4.Name = "label4";
            label4.Size = new Size(77, 21);
            label4.TabIndex = 4;
            label4.Text = "Seed Link";
            // 
            // lblLoginStatus
            // 
            lblLoginStatus.AutoSize = true;
            lblLoginStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginStatus.Location = new Point(22, 65);
            lblLoginStatus.Name = "lblLoginStatus";
            lblLoginStatus.Size = new Size(66, 21);
            lblLoginStatus.TabIndex = 3;
            lblLoginStatus.Text = "Not yet!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(22, 252);
            label3.Name = "label3";
            label3.Size = new Size(184, 21);
            label3.TabIndex = 2;
            label3.Text = "Step 3: Wait for the result";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(22, 114);
            label2.Name = "label2";
            label2.Size = new Size(318, 21);
            label2.TabIndex = 1;
            label2.Text = "Step 2: Fill Seed Link and start Crawling Data";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(22, 21);
            label1.Name = "label1";
            label1.Size = new Size(99, 21);
            label1.TabIndex = 0;
            label1.Text = "Step 1: Login";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 383);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Crawler";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblProcessStatus;
        private Button btnCrawlData;
        private TextBox txtSeedLink;
        private Label label4;
        private Label lblLoginStatus;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}