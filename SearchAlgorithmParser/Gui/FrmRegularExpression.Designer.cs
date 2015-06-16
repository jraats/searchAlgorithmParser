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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRegex = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblParsedRegex = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbToNDFA});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(541, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbToNDFA
            // 
            this.tsbToNDFA.Image = ((System.Drawing.Image)(resources.GetObject("tsbToNDFA.Image")));
            this.tsbToNDFA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToNDFA.Name = "tsbToNDFA";
            this.tsbToNDFA.Size = new System.Drawing.Size(75, 22);
            this.tsbToNDFA.Text = "To NDFA";
            this.tsbToNDFA.Click += new System.EventHandler(this.tsbToNDFA_Click);
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
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(322, 47);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
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
            this.Controls.Add(this.btnRun);
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
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblParsedRegex;
    }
}