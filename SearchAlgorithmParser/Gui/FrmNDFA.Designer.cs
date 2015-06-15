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
            this.tsbToDFA = new System.Windows.Forms.ToolStripButton();
            this.tsbToRegram = new System.Windows.Forms.ToolStripButton();
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
            this.dgvAlphabet = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlphabet)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbToPng,
            this.tsbToDFA,
            this.tsbToRegram});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(533, 25);
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
            this.tsbToPng.Click += new System.EventHandler(this.tsbToPng_Click);
            // 
            // tsbToDFA
            // 
            this.tsbToDFA.Image = ((System.Drawing.Image)(resources.GetObject("tsbToDFA.Image")));
            this.tsbToDFA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToDFA.Name = "tsbToDFA";
            this.tsbToDFA.Size = new System.Drawing.Size(66, 22);
            this.tsbToDFA.Text = "To DFA";
            this.tsbToDFA.Click += new System.EventHandler(this.tsbToDFA_Click);
            // 
            // tsbToRegram
            // 
            this.tsbToRegram.Image = ((System.Drawing.Image)(resources.GetObject("tsbToRegram.Image")));
            this.tsbToRegram.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToRegram.Name = "tsbToRegram";
            this.tsbToRegram.Size = new System.Drawing.Size(140, 22);
            this.tsbToRegram.Text = "To Regulair Grammar";
            this.tsbToRegram.Click += new System.EventHandler(this.tsbToRegram_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(102, 17);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Create NDFA";
            // 
            // dgvStates
            // 
            this.dgvStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnName,
            this.clnStartState,
            this.clnEndState});
            this.dgvStates.Location = new System.Drawing.Point(184, 58);
            this.dgvStates.Name = "dgvStates";
            this.dgvStates.Size = new System.Drawing.Size(349, 82);
            this.dgvStates.TabIndex = 4;
            this.dgvStates.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStates_CellEndEdit);
            this.dgvStates.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvStates_UserDeletedRow);
            this.dgvStates.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvStates_UserDeletingRow);
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
            this.lblAlpabeth.Location = new System.Drawing.Point(12, 42);
            this.lblAlpabeth.Name = "lblAlpabeth";
            this.lblAlpabeth.Size = new System.Drawing.Size(52, 13);
            this.lblAlpabeth.TabIndex = 5;
            this.lblAlpabeth.Text = "Alpabeth:";
            // 
            // lblStates
            // 
            this.lblStates.AutoSize = true;
            this.lblStates.Location = new System.Drawing.Point(181, 42);
            this.lblStates.Name = "lblStates";
            this.lblStates.Size = new System.Drawing.Size(37, 13);
            this.lblStates.TabIndex = 6;
            this.lblStates.Text = "States";
            // 
            // lblTransitions
            // 
            this.lblTransitions.AutoSize = true;
            this.lblTransitions.Location = new System.Drawing.Point(9, 143);
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
            this.dgvTransitions.Location = new System.Drawing.Point(12, 159);
            this.dgvTransitions.Name = "dgvTransitions";
            this.dgvTransitions.Size = new System.Drawing.Size(521, 54);
            this.dgvTransitions.TabIndex = 7;
            this.dgvTransitions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTransitions_DataError);
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
            // dgvAlphabet
            // 
            this.dgvAlphabet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlphabet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvAlphabet.Location = new System.Drawing.Point(15, 58);
            this.dgvAlphabet.Name = "dgvAlphabet";
            this.dgvAlphabet.Size = new System.Drawing.Size(163, 82);
            this.dgvAlphabet.TabIndex = 9;
            this.dgvAlphabet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlphabet_CellEndEdit);
            this.dgvAlphabet.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAlphabet_CellValidating);
            this.dgvAlphabet.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvAlphabet_UserDeletedRow);
            this.dgvAlphabet.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAlphabet_UserDeletingRow);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // FrmNDFA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 225);
            this.Controls.Add(this.dgvAlphabet);
            this.Controls.Add(this.lblAlpabeth);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStates);
            this.Controls.Add(this.lblTransitions);
            this.Controls.Add(this.dgvTransitions);
            this.Controls.Add(this.dgvStates);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmNDFA";
            this.Text = "Create NDFA";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlphabet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbToPng;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvStates;
        private System.Windows.Forms.Label lblAlpabeth;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnStartState;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnEndState;
        private System.Windows.Forms.Label lblStates;
        private System.Windows.Forms.Label lblTransitions;
        private System.Windows.Forms.DataGridView dgvTransitions;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnFromState;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnToState;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnSymbol;
        private System.Windows.Forms.DataGridView dgvAlphabet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripButton tsbToRegram;
        private System.Windows.Forms.ToolStripButton tsbToDFA;
    }
}