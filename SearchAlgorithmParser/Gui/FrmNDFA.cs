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
    public partial class FrmNDFA : Form
    {
        public FrmNDFA()
        {
            InitializeComponent();

            List<char> theList = new List<char>(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' });

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)this.dgvTransitions.Columns[2];
            column.DataSource = theList;

        }

        private void dgvAlphabet_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            Console.WriteLine(row.Cells[0].Value);
        }

        private void dgvAlphabet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            char addedLetter = this.dgvAlphabet.Rows[e.RowIndex].Cells[0].Value.ToString().First();
        }

        private void dgvAlphabet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            e.Cancel = String.IsNullOrEmpty((string)e.FormattedValue);
        }
    }
}
