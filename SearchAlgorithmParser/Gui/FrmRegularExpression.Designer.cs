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
            this.lblResult = new System.Windows.Forms.Label();
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.btnInsertTerminal = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnStar = new System.Windows.Forms.Button();
            this.btnChoice = new System.Windows.Forms.Button();
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
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(119, 52);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(121, 13);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Enter one of the buttons";
            // 
            // txtTerminal
            // 
            this.txtTerminal.Location = new System.Drawing.Point(15, 79);
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.Size = new System.Drawing.Size(100, 20);
            this.txtTerminal.TabIndex = 7;
            // 
            // btnInsertTerminal
            // 
            this.btnInsertTerminal.Location = new System.Drawing.Point(121, 77);
            this.btnInsertTerminal.Name = "btnInsertTerminal";
            this.btnInsertTerminal.Size = new System.Drawing.Size(93, 23);
            this.btnInsertTerminal.TabIndex = 8;
            this.btnInsertTerminal.Text = "Insert Terminal";
            this.btnInsertTerminal.UseVisualStyleBackColor = true;
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(15, 106);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(75, 23);
            this.btnPlus.TabIndex = 9;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(96, 106);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(75, 23);
            this.btnStar.TabIndex = 10;
            this.btnStar.Text = "*";
            this.btnStar.UseVisualStyleBackColor = true;
            // 
            // btnChoice
            // 
            this.btnChoice.Location = new System.Drawing.Point(178, 105);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(75, 23);
            this.btnChoice.TabIndex = 11;
            this.btnChoice.Text = "Choice";
            this.btnChoice.UseVisualStyleBackColor = true;
            // 
            // FrmRegularExpression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 261);
            this.Controls.Add(this.btnChoice);
            this.Controls.Add(this.btnStar);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnInsertTerminal);
            this.Controls.Add(this.txtTerminal);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblRegex);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmRegularExpression";
            this.Text = "Regular Expression";
            this.Load += new System.EventHandler(this.FrmRegularExpression_Load);
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
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtTerminal;
        private System.Windows.Forms.Button btnInsertTerminal;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.Button btnChoice;
    }
}