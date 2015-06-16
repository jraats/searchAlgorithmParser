namespace Gui
{
    partial class FrmRegularExpression
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegularExpression));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbToNDFA = new System.Windows.Forms.ToolStripButton();
            this.tsbVerifyMachine = new System.Windows.Forms.ToolStripButton();
            this.tsbVerifyLanguage = new System.Windows.Forms.ToolStripButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRegex = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblParsedRegex = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbToNDFA,
            this.tsbVerifyMachine,
            this.tsbVerifyLanguage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(541, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbToNDFA
            // 
            this.tsbToNDFA.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbToNDFA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbToNDFA.Enabled = false;
            this.tsbToNDFA.Image = ((System.Drawing.Image)(resources.GetObject("tsbToNDFA.Image")));
            this.tsbToNDFA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToNDFA.Name = "tsbToNDFA";
            this.tsbToNDFA.Size = new System.Drawing.Size(59, 22);
            this.tsbToNDFA.Text = "To NDFA";
            this.tsbToNDFA.Click += new System.EventHandler(this.tsbToNDFA_Click);
            // 
            // tsbVerifyMachine
            // 
            this.tsbVerifyMachine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVerifyMachine.Image = ((System.Drawing.Image)(resources.GetObject("tsbVerifyMachine.Image")));
            this.tsbVerifyMachine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVerifyMachine.Name = "tsbVerifyMachine";
            this.tsbVerifyMachine.Size = new System.Drawing.Size(90, 22);
            this.tsbVerifyMachine.Text = "Verify Machine";
            this.tsbVerifyMachine.Click += new System.EventHandler(this.tsbVerifyMachine_Click);
            // 
            // tsbVerifyLanguage
            // 
            this.tsbVerifyLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVerifyLanguage.Enabled = false;
            this.tsbVerifyLanguage.Image = ((System.Drawing.Image)(resources.GetObject("tsbVerifyLanguage.Image")));
            this.tsbVerifyLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVerifyLanguage.Name = "tsbVerifyLanguage";
            this.tsbVerifyLanguage.Size = new System.Drawing.Size(96, 22);
            this.tsbVerifyLanguage.Text = "Verify Language";
            this.tsbVerifyLanguage.Click += new System.EventHandler(this.tsbVerifyLanguage_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(202, 17);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Create Regular Expression";
            // 
            // lblRegex
            // 
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(12, 52);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(101, 13);
            this.lblRegex.TabIndex = 5;
            this.lblRegex.Text = "Regular Expression:";
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(119, 49);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(197, 20);
            this.txtRegex.TabIndex = 6;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(12, 72);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(138, 13);
            this.lblCurrent.TabIndex = 8;
            this.lblCurrent.Text = "Current Regular Expression:";
            // 
            // lblParsedRegex
            // 
            this.lblParsedRegex.AutoSize = true;
            this.lblParsedRegex.Location = new System.Drawing.Point(12, 85);
            this.lblParsedRegex.Name = "lblParsedRegex";
            this.lblParsedRegex.Size = new System.Drawing.Size(79, 13);
            this.lblParsedRegex.TabIndex = 9;
            this.lblParsedRegex.Text = "Enter the regex";
            // 
            // FrmRegularExpression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.lblParsedRegex);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.lblRegex);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmRegularExpression";
            this.Text = "Regular Expression";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbToNDFA;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRegex;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblParsedRegex;
        private System.Windows.Forms.ToolStripButton tsbVerifyMachine;
        private System.Windows.Forms.ToolStripButton tsbVerifyLanguage;
    }
}