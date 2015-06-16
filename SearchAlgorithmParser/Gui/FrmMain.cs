using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
        }

        private void regularExpressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegularExpression regularExpression = new FrmRegularExpression();
            regularExpression.MdiParent = this;
            regularExpression.WindowState = FormWindowState.Maximized;
            regularExpression.Show();
        }

        private void regularGrammarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegularGrammar regularGrammar = new FrmRegularGrammar();
            regularGrammar.MdiParent = this;
            regularGrammar.WindowState = FormWindowState.Maximized;
            regularGrammar.Show();
        }

        private void nDFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNDFA ndfa = new FrmNDFA();
            ndfa.MdiParent = this;
            ndfa.WindowState = FormWindowState.Maximized;
            ndfa.Show();
        }

        private void dFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDFA dfa = new FrmDFA();
            dfa.MdiParent = this;
            dfa.WindowState = FormWindowState.Maximized;
            dfa.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Equals(this.helpToolStripMenuItem))
            {
                while (this.helpToolStripMenuItem.DropDownItems.Count > 1)
                {
                    this.helpToolStripMenuItem.DropDownItems.RemoveAt(1);
                }
                this.helpToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

                foreach(Form item in this.MdiChildren) {
                    this.helpToolStripMenuItem.DropDownItems.Add("*" + item.Text);
                    this.helpToolStripMenuItem.DropDownItems[this.helpToolStripMenuItem.DropDownItems.Count - 1].Click += mdiChild_ItemClicked;
                }
            }
        }

        private void mdiChild_ItemClicked(object sender, EventArgs e)
        {
            int index = this.helpToolStripMenuItem.DropDownItems.IndexOf((ToolStripItem)sender);
            if (index == -1)
                return;

            this.MdiChildren[index - 2].Focus();
        }
    }
}
