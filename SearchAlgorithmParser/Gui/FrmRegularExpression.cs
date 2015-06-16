using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchAlgorithmParser;
using SearchAlgorithmParser.Regex;

namespace Gui
{
    public partial class FrmRegularExpression : Form
    {
        Regex<string> regex;

        public FrmRegularExpression()
        {
            InitializeComponent();

        }

        private void updateGui()
        {
            if(this.regex != null)
            {
                this.lblParsedRegex.Text = regex.ToString();
            }
        }

        private void tsbToNDFA_Click(object sender, EventArgs e)
        {
            if (this.regex != null)
            {
                NDFA<string, char> ndfa = SearchAlgorithmParser.Converter<string, char>.ConvertToNDFA(this.regex, 'e');
                FrmNDFA frmNdfa = new FrmNDFA(ndfa);
                frmNdfa.MdiParent = this.MdiParent;
                frmNdfa.Show();
            }
        }

        private void tsbVerifyMachine_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtRegex.Text))
                return;

            try
            {
                regex = new Regex<string>(new char[] { 'a', 'b' }, this.txtRegex.Text, new StringStateCreater("LR_"));
            }
            catch (Exception)
            {
                MessageBox.Show("Regex is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tsbToNDFA.Enabled = true;
            tsbVerifyLanguage.Enabled = true;
            updateGui();
        }

        private void tsbVerifyLanguage_Click(object sender, EventArgs e)
        {
        }
    }
}
