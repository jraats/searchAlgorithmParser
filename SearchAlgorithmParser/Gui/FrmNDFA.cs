﻿using System;
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
    public partial class FrmNDFA : Form
    {

        DataTableColumnSource<char> alphabetSource;
        DataTableColumnSource<string> stateSource;
        int lastDeletedIndex;

        public FrmNDFA()
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

        private NDFA<string, char> getNDFA()
        {
            NDFA<string, char> ndfa = new NDFA<string, char>(this.alphabetSource.Cast<char>().ToArray(), 'e');

            foreach (DataGridViewRow dataRow in this.dgvTransitions.Rows)
            {
                if (dataRow.Cells[2].Value == null || dataRow.Cells[2].Value.ToString() == "")
                    continue;

                string from = dataRow.Cells[0].Value.ToString();
                string to = dataRow.Cells[1].Value.ToString();
                char symbol = dataRow.Cells[2].Value.ToString().First();
                ndfa.AddTransition(from, to, symbol);
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
                    ndfa.StartState = name;
                }
                if (endState)
                {
                    ndfa.EndStates.Add(name);
                }
            }

            if (!ndfa.IsMachineValid())
            {
                MessageBox.Show("Machine is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return ndfa;
        }

        private void tsbToDFA_Click(object sender, EventArgs e)
        {
            NDFA<string, char> ndfa = getNDFA();
            if (ndfa == null)
                return;

            DFA<MultiState<string>, char> dfa = SearchAlgorithmParser.Converter<string, char>.ConvertToDFA(ndfa, new SearchAlgorithmParser.MultiStateViewConcat<string>("", "O"));
            FrmDFA frmDfa = new FrmDFA(dfa);
            frmDfa.MdiParent = this.MdiParent;
            frmDfa.Show();
        }

        private void tsbToRegram_Click(object sender, EventArgs e)
        {
           /* NDFA<string, char> ndfa = getNDFA();
            if (ndfa == null)
                return;

            Regram<MultiState<string>, char> dfa = SearchAlgorithmParser.Converter<string, char>.ConvertToRegram(ndfa, new SearchAlgorithmParser.MultiStateViewConcat<string>("", "O"));
            FrmRegularGrammar frmRegram = new FrmRegularGrammar(dfa);
            frmRegram.MdiParent = this.MdiParent;
            frmRegram.Show();*/
        }

        private void tsbToPng_Click(object sender, EventArgs e)
        {
            NDFA<string, char> ndfa = getNDFA();
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
