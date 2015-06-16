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
    public partial class FrmRegularGrammar : Form
    {
        DataTableColumnSource<char> alphabetSource;
        DataTableColumnSource<string> stateSource;
        int lastDeletedIndex;

        public FrmRegularGrammar()
        {
            InitializeComponent();

            alphabetSource = new DataTableColumnSource<char>(ref this.dgvAlphabet, 0, new char[]{'e'});
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

        public FrmRegularGrammar(Grammar<string, char> ndfa) : this()
        {
            foreach(char c in ndfa.Alphabet)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = c;
                this.dgvAlphabet.Rows.Add(row);
                this.alphabetSource.PosibleChange(ListChangedType.ItemAdded, this.dgvAlphabet.Rows.Count);
            }

            foreach (string state in ndfa.GetStates())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells.Add(new DataGridViewCheckBoxCell());
                row.Cells.Add(new DataGridViewCheckBoxCell());
                row.Cells[0].Value = state.ToString();
                row.Cells[1].Value = (ndfa.StartState.Equals(state));
                row.Cells[2].Value = ndfa.EndStates.Contains(state);
                this.dgvStates.Rows.Add(row);
                this.stateSource.PosibleChange(ListChangedType.ItemAdded, this.dgvStates.Rows.Count);
            }

            foreach (string state in ndfa.GetStates())
            {
                Dictionary<char, HashSet<string>> toState = ndfa.GetStates(state);

                foreach(char key in toState.Keys)
                {
                    foreach (string toStateName in toState[key])
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
                        ((DataGridViewComboBoxCell)tRow.Cells[1]).Value = toStateName.ToString();

                        BindingSource clm3BS = new BindingSource();
                        clm3BS.DataSource = alphabetSource;
                        ((DataGridViewComboBoxCell)tRow.Cells[2]).DataSource = clm3BS;
                        ((DataGridViewComboBoxCell)tRow.Cells[2]).ValueType = typeof(char);
                        ((DataGridViewComboBoxCell)tRow.Cells[2]).Value = key;
                    }
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

        private void dgvTransitions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private Regram<string, char> getRegram()
        {
            Regram<string, char> regram = new Regram<string, char>(this.alphabetSource.GetTableArray());

            foreach (DataGridViewRow dataRow in this.dgvTransitions.Rows)
            {
                if (dataRow.Cells[2].Value == null || dataRow.Cells[2].Value.ToString() == "")
                    continue;

                string from = dataRow.Cells[0].Value.ToString();
                string to = dataRow.Cells[1].Value.ToString();
                char symbol = dataRow.Cells[2].Value.ToString().First();
                regram.AddTransition(from, to, symbol);
            }

            foreach (DataGridViewRow dataRow in this.dgvStates.Rows)
            {
                if (dataRow.Cells[0].Value == null || dataRow.Cells[0].Value.ToString() == "")
                    continue;

                string name = dataRow.Cells[0].Value.ToString();
                bool startState = (((dataRow.Cells[1]).Value == null) ? false : (bool)(dataRow.Cells[1]).Value);
                bool endState = (((dataRow.Cells[2]).Value == null) ? false : (bool)(dataRow.Cells[2]).Value);

                if (startState)
                {
                    regram.StartState = name;
                }
                if (endState)
                {
                    regram.EndStates.Add(name);
                }
            }

            if (!regram.IsMachineValid())
            {
                MessageBox.Show("Machine is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            tsbToDFA.Enabled = true;
            tsbToNDFA.Enabled = true;
            tsbVerifyLanguage.Enabled = true;
            return regram;
        }

        private void tsbToDFA_Click(object sender, EventArgs e)
        {
            Regram<string, char> regram = getRegram();
            if (regram == null)
                return;

            DFA<MultiState<string>, char> dfa = SearchAlgorithmParser.Converter<string, char>.ConvertToDFA(regram, new SearchAlgorithmParser.MultiStateViewConcat<string>("", "O"));
            FrmDFA frmDfa = new FrmDFA(dfa);
            frmDfa.MdiParent = this.MdiParent;
            frmDfa.Show();
        }

        private void tsbToNDFA_Click(object sender, EventArgs e)
        {
            Regram<string, char> regram = getRegram();
            if (regram == null)
                return;

            NDFA<string, char> ndfa = SearchAlgorithmParser.Converter<string, char>.ConvertToNDFA(regram, 'e');
            FrmNDFA frmNdfa = new FrmNDFA(ndfa);
            frmNdfa.MdiParent = this.MdiParent;
            frmNdfa.Show();
        }

        private void tsbVerifyMachine_Click(object sender, EventArgs e)
        {
            Regram<string, char> regram = getRegram();
            if (regram == null)
                return;
        }

        private void tsbVerifyLanguage_Click(object sender, EventArgs e)
        {

        }
    }
}
