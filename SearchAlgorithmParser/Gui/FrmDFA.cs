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

namespace Gui
{
    public partial class FrmDFA : Form
    {

        DataTableColumnSource<char> alphabetSource;
        DataTableColumnSource<string> stateSource;
        int lastDeletedIndex;

        public FrmDFA()
        {
            InitializeComponent();

            alphabetSource = new DataTableColumnSource<char>(ref this.dgvAlphabet, 0);
            stateSource = new DataTableColumnSource<string>(ref this.dgvStates, 0);

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)this.dgvTransitions.Columns[0];
            BindingSource clm1BS = new BindingSource();
            clm1BS.DataSource = stateSource;
            column.DataSource = clm1BS;
            column.ValueType = typeof(string);

            column = (DataGridViewComboBoxColumn)this.dgvTransitions.Columns[1];
            BindingSource clm2BS = new BindingSource();
            clm2BS.DataSource = stateSource;
            column.DataSource = clm2BS;
            column.ValueType = typeof(string);
            
            column = (DataGridViewComboBoxColumn)this.dgvTransitions.Columns[2];
            BindingSource clm3BS = new BindingSource();
            clm3BS.DataSource = alphabetSource;
            column.DataSource = clm3BS;
            column.ValueType = typeof(char);

        }

        public FrmDFA(DFA<MultiState<string>, char> dfa) : this()
        {
            foreach(char c in dfa.Alphabet)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = c;
                this.dgvAlphabet.Rows.Add(row);
                this.alphabetSource.PosibleChange(ListChangedType.ItemAdded, this.dgvAlphabet.Rows.Count);
            }

            foreach (MultiState<string> state in dfa.GetStates())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells.Add(new DataGridViewCheckBoxCell());
                row.Cells.Add(new DataGridViewCheckBoxCell());
                row.Cells[0].Value = state.ToString();
                row.Cells[1].Value = (dfa.StartState.Equals(state));
                row.Cells[2].Value = dfa.EndStates.Contains(state);
                this.dgvStates.Rows.Add(row);
                this.stateSource.PosibleChange(ListChangedType.ItemAdded, this.dgvStates.Rows.Count);
            }

            foreach (MultiState<string> state in dfa.GetStates())
            {
                Dictionary<char, MultiState<string>> toState = dfa.GetStates(state);

                foreach(char key in toState.Keys)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewComboBoxCell());
                    row.Cells.Add(new DataGridViewComboBoxCell());
                    row.Cells.Add(new DataGridViewComboBoxCell());
                    this.dgvTransitions.Rows.Add(row);

                    DataGridViewRow tRow = this.dgvTransitions.Rows[this.dgvTransitions.Rows.Count - 2];

                     BindingSource clm1BS = new BindingSource();
                    clm1BS.DataSource = stateSource;

                    ((DataGridViewComboBoxCell)tRow.Cells[0]).DataSource = clm1BS;
                    ((DataGridViewComboBoxCell)tRow.Cells[0]).ValueType = typeof(char);
                    ((DataGridViewComboBoxCell)tRow.Cells[0]).Value = state.ToString();

                    BindingSource clm2BS = new BindingSource();
                    clm2BS.DataSource = stateSource;
                    ((DataGridViewComboBoxCell)tRow.Cells[1]).DataSource = clm2BS;
                    ((DataGridViewComboBoxCell)tRow.Cells[1]).ValueType = typeof(string);
                    ((DataGridViewComboBoxCell)tRow.Cells[1]).Value = toState[key].ToString();

                    BindingSource clm3BS = new BindingSource();
                    clm3BS.DataSource = alphabetSource;
                    ((DataGridViewComboBoxCell)tRow.Cells[2]).DataSource = clm3BS;
                    ((DataGridViewComboBoxCell)tRow.Cells[2]).ValueType = typeof(char);
                    ((DataGridViewComboBoxCell)tRow.Cells[2]).Value = key;
                }
            }
        }

        public FrmDFA(DFA<string, char> dfa)
            : this()
        {
            foreach (char c in dfa.Alphabet)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = c;
                this.dgvAlphabet.Rows.Add(row);
                this.alphabetSource.PosibleChange(ListChangedType.ItemAdded, this.dgvAlphabet.Rows.Count);
            }

            foreach (string state in dfa.GetStates())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells.Add(new DataGridViewCheckBoxCell());
                row.Cells.Add(new DataGridViewCheckBoxCell());
                row.Cells[0].Value = state.ToString();
                row.Cells[1].Value = (dfa.StartState.Equals(state));
                row.Cells[2].Value = dfa.EndStates.Contains(state);
                this.dgvStates.Rows.Add(row);
                this.stateSource.PosibleChange(ListChangedType.ItemAdded, this.dgvStates.Rows.Count);
            }

            foreach (string state in dfa.GetStates())
            {
                Dictionary<char, string> toState = dfa.GetStates(state);

                foreach (char key in toState.Keys)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewComboBoxCell());
                    row.Cells.Add(new DataGridViewComboBoxCell());
                    row.Cells.Add(new DataGridViewComboBoxCell());
                    this.dgvTransitions.Rows.Add(row);

                    DataGridViewRow tRow = this.dgvTransitions.Rows[this.dgvTransitions.Rows.Count - 2];

                    BindingSource clm1BS = new BindingSource();
                    clm1BS.DataSource = stateSource;

                    ((DataGridViewComboBoxCell)tRow.Cells[0]).DataSource = clm1BS;
                    ((DataGridViewComboBoxCell)tRow.Cells[0]).ValueType = typeof(char);
                    ((DataGridViewComboBoxCell)tRow.Cells[0]).Value = state.ToString();

                    BindingSource clm2BS = new BindingSource();
                    clm2BS.DataSource = stateSource;
                    ((DataGridViewComboBoxCell)tRow.Cells[1]).DataSource = clm2BS;
                    ((DataGridViewComboBoxCell)tRow.Cells[1]).ValueType = typeof(string);
                    ((DataGridViewComboBoxCell)tRow.Cells[1]).Value = toState[key].ToString();

                    BindingSource clm3BS = new BindingSource();
                    clm3BS.DataSource = alphabetSource;
                    ((DataGridViewComboBoxCell)tRow.Cells[2]).DataSource = clm3BS;
                    ((DataGridViewComboBoxCell)tRow.Cells[2]).ValueType = typeof(char);
                    ((DataGridViewComboBoxCell)tRow.Cells[2]).Value = key;
                }
            }
        }

        private void dgvAlphabet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            lastDeletedIndex = e.Row.Index;
        }

        private void dgvAlphabet_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            string value = (row.Cells[0].Value != null)? row.Cells[0].Value.ToString() : "";
            
            alphabetSource.PosibleChange(ListChangedType.ItemDeleted, lastDeletedIndex);

            List<DataGridViewRow> removeRows = new List<DataGridViewRow>();
            //Update transitions
            foreach (DataGridViewRow dataRow in this.dgvTransitions.Rows)
            {
                if (dataRow.Cells[2].Value != null && dataRow.Cells[2].Value.ToString().Equals(value))
                    removeRows.Add(dataRow);
            }

                
            foreach(DataGridViewRow dataRow in removeRows)
            {
                this.dgvTransitions.Rows.Remove(dataRow);
            }
        }

        private void dgvAlphabet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dgvAlphabet.Rows[e.RowIndex].IsNewRow)
                alphabetSource.PosibleChange(ListChangedType.ItemAdded, e.RowIndex);
            else
                alphabetSource.PosibleChange(ListChangedType.ItemChanged, e.RowIndex);

        }

        private void dgvAlphabet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            e.Cancel = e.FormattedValue != null && e.FormattedValue.ToString().Length > 1;
        }

        private void dgvStates_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            lastDeletedIndex = e.Row.Index;
        }

        private void dgvStates_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = e.Row;
            string value = (row.Cells[0].Value != null) ? row.Cells[0].Value.ToString() : "";
            stateSource.PosibleChange(ListChangedType.ItemDeleted, lastDeletedIndex);
            
            List<DataGridViewRow> removeRows = new List<DataGridViewRow>();
            //Update transitions
            foreach (DataGridViewRow dataRow in this.dgvTransitions.Rows)
            {
                if (dataRow.Cells[0].Value != null && dataRow.Cells[0].Value.Equals(value))
                    removeRows.Add(dataRow);
                else if (dataRow.Cells[1].Value != null && dataRow.Cells[1].Value.Equals(value))
                    removeRows.Add(dataRow);
            }

            foreach(DataGridViewRow dataRow in removeRows)
            {
                this.dgvTransitions.Rows.Remove(dataRow);
            }
        }

        private void dgvStates_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            stateSource.PosibleChange(ListChangedType.ItemChanged, e.RowIndex);

        }

        private DFA<string, char> getDFA()
        {
            DFA<string, char> dfa = new DFA<string, char>(this.alphabetSource.Cast<char>().ToArray(), "LR_x");

            foreach (DataGridViewRow dataRow in this.dgvTransitions.Rows)
            {
                if (dataRow.Cells[2].Value == null || dataRow.Cells[2].Value.ToString() == "")
                    continue;

                string from = dataRow.Cells[0].Value.ToString();
                string to = dataRow.Cells[1].Value.ToString();
                char symbol = dataRow.Cells[2].Value.ToString().First();
                dfa.AddTransition(from, to, symbol);
            }

            foreach (DataGridViewRow dataRow in this.dgvStates.Rows)
            {
                if (dataRow.Cells[0].Value == null || dataRow.Cells[0].Value.ToString() == "")
                    continue;

                string name = dataRow.Cells[0].Value.ToString();
                bool startState = !((dataRow.Cells[1]).Value == null);
                bool endState = !((dataRow.Cells[2]).Value == null);

                if (startState)
                {
                    dfa.StartState = name;
                }
                if (endState)
                {
                    dfa.EndStates.Add(name);
                }
            }

            if (!dfa.IsMachineValid())
            {
                MessageBox.Show("Machine is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return dfa;
        }

        private void tsbToMinimalDFA_Click(object sender, EventArgs e)
        {
            DFA<string, char> dfa = getDFA();
            dfa.MinimaliseDFA();
            FrmDFA frmDfa = new FrmDFA(dfa);
            frmDfa.MdiParent = this.MdiParent;
            frmDfa.Show();
        }

        private void tsbToRegram_Click(object sender, EventArgs e)
        {
            DFA<string, char> dfa = getDFA();
            if (dfa == null)
                return;

            Regram<string, char> regram = SearchAlgorithmParser.Converter<string, char>.ConvertToRegram(dfa);
            FrmRegularGrammar frmRegram = new FrmRegularGrammar(regram);
            frmRegram.MdiParent = this.MdiParent;
            frmRegram.Show();
        }

        private void tsbToPng_Click(object sender, EventArgs e)
        {
            DFA<string, char> ndfa = getDFA();
            if (ndfa == null)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = ".png";
            dialog.Filter = "*.png|.png";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ndfa.MakePngFile(dialog.FileName);
                FrmImage image = new FrmImage();
                image.SetPicture(dialog.FileName);
                image.MdiParent = this.MdiParent;
                image.Show();
            }
        }

        private void dgvTransitions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
