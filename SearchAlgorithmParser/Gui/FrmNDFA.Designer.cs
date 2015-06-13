namespace Gui
{
    partial class FrmNDFA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNDFA));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbToPng = new System.Windows.Forms.ToolStripButton();
            this.dgvAlphabet = new System.Windows.Forms.DataGridView();
            this.clnAlphabet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvStates = new System.Windows.Forms.DataGridView();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnStartState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnEndState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblAlpabeth = new System.Windows.Forms.Label();
            this.lblStates = new System.Windows.Forms.Label();
            this.lblTransitions = new System.Windows.Forms.Label();
            this.dgvTransitions = new System.Windows.Forms.DataGridView();
            this.clnFromState = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnToState = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnSymbol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbToPng});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(357, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbToPng
            // 
            this.tsbToPng.Image = ((System.Drawing.Image)(resources.GetObject("tsbToPng.Image")));
            this.tsbToPng.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToPng.Name = "tsbToPng";
            this.tsbToPng.Size = new System.Drawing.Size(68, 22);
            this.tsbToPng.Text = "To PNG";
            // 
            // dgvAlphabet
            // 
            this.dgvAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlphabet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlphabet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnAlphabet});
            this.dgvAlphabet.Location = new System.Drawing.Point(3, 41);
            this.dgvAlphabet.Name = "dgvAlphabet";
            this.dgvAlphabet.Size = new System.Drawing.Size(351, 57);
            this.dgvAlphabet.TabIndex = 1;
            this.dgvAlphabet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlphabet_CellEndEdit);
            this.dgvAlphabet.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAlphabet_CellValidating);
            this.dgvAlphabet.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvAlphabet_UserDeletedRow);
            // 
            // clnAlphabet
            // 
            this.clnAlphabet.HeaderText = "Alphabet";
            this.clnAlphabet.Name = "clnAlphabet";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(102, 17);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Create NDFA";
            // 
            // dgvStates
            // 
            this.dgvStates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnName,
            this.clnStartState,
            this.clnEndState});
            this.dgvStates.Location = new System.Drawing.Point(3, 16);
            this.dgvStates.Name = "dgvStates";
            this.dgvStates.Size = new System.Drawing.Size(351, 77);
            this.dgvStates.TabIndex = 4;
            // 
            // clnName
            // 
            this.clnName.HeaderText = "Name";
            this.clnName.Name = "clnName";
            // 
            // clnStartState
            // 
            this.clnStartState.HeaderText = "Start state";
            this.clnStartState.Name = "clnStartState";
            // 
            // clnEndState
            // 
            this.clnEndState.HeaderText = "End state";
            this.clnEndState.Name = "clnEndState";
            // 
            // lblAlpabeth
            // 
            this.lblAlpabeth.AutoSize = true;
            this.lblAlpabeth.Location = new System.Drawing.Point(12, 25);
            this.lblAlpabeth.Name = "lblAlpabeth";
            this.lblAlpabeth.Size = new System.Drawing.Size(52, 13);
            this.lblAlpabeth.TabIndex = 5;
            this.lblAlpabeth.Text = "Alpabeth:";
            // 
            // lblStates
            // 
            this.lblStates.AutoSize = true;
            this.lblStates.Location = new System.Drawing.Point(12, 0);
            this.lblStates.Name = "lblStates";
            this.lblStates.Size = new System.Drawing.Size(37, 13);
            this.lblStates.TabIndex = 6;
            this.lblStates.Text = "States";
            // 
            // lblTransitions
            // 
            this.lblTransitions.AutoSize = true;
            this.lblTransitions.Location = new System.Drawing.Point(12, 0);
            this.lblTransitions.Name = "lblTransitions";
            this.lblTransitions.Size = new System.Drawing.Size(58, 13);
            this.lblTransitions.TabIndex = 8;
            this.lblTransitions.Text = "Transitions";
            // 
            // dgvTransitions
            // 
            this.dgvTransitions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransitions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnFromState,
            this.clnToState,
            this.clnSymbol});
            this.dgvTransitions.Location = new System.Drawing.Point(3, 16);
            this.dgvTransitions.Name = "dgvTransitions";
            this.dgvTransitions.Size = new System.Drawing.Size(351, 85);
            this.dgvTransitions.TabIndex = 7;
            // 
            // clnFromState
            // 
            this.clnFromState.HeaderText = "From";
            this.clnFromState.Name = "clnFromState";
            // 
            // clnToState
            // 
            this.clnToState.HeaderText = "To";
            this.clnToState.Name = "clnToState";
            // 
            // clnSymbol
            // 
            this.clnSymbol.HeaderText = "Symbol";
            this.clnSymbol.Name = "clnSymbol";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTitle);
            this.splitContainer1.Panel1.Controls.Add(this.lblAlpabeth);
            this.splitContainer1.Panel1.Controls.Add(this.dgvAlphabet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(357, 309);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblStates);
            this.splitContainer2.Panel1.Controls.Add(this.dgvStates);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblTransitions);
            this.splitContainer2.Panel2.Controls.Add(this.dgvTransitions);
            this.splitContainer2.Size = new System.Drawing.Size(357, 204);
            this.splitContainer2.SplitterDistance = 96;
            this.splitContainer2.TabIndex = 0;
            // 
            // FrmNDFA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 334);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmNDFA";
            this.Text = "Create NDFA";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransitions)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbToPng;
        private System.Windows.Forms.DataGridView dgvAlphabet;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvStates;
        private System.Windows.Forms.Label lblAlpabeth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAlphabet;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnStartState;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnEndState;
        private System.Windows.Forms.Label lblStates;
        private System.Windows.Forms.Label lblTransitions;
        private System.Windows.Forms.DataGridView dgvTransitions;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnFromState;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnToState;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnSymbol;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}