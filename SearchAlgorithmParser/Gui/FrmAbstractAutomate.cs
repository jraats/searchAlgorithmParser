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
    public abstract partial class FrmAbstractAutomate : Form
    {
        DataTableColumnSource<char> alphabetSource;
        DataTableColumnSource<string> stateSource;
        int lastDeletedIndex;

        public FrmAbstractAutomate()
        {
            InitializeComponent();

            this.lblTitle.Text = this.GetTitle();

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
            string value = (row.Cells[0].Value != null) ? row.Cells[0].Value.ToString() : "";

            alphabetSource.PosibleChange(ListChangedType.ItemDeleted, lastDeletedIndex);

            List<DataGridViewRow> removeRows = new List<DataGridViewRow>();
            //Update transitions
            foreach (DataGridViewRow dataRow in this.dgvTransitions.Rows)
            {
                if (dataRow.Cells[2].Value != null && dataRow.Cells[2].Value.ToString().Equals(value))
                    removeRows.Add(dataRow);
            }


            foreach (DataGridViewRow dataRow in removeRows)
            {
                this.dgvTransitions.Rows.Remove(dataRow);
            }
        }

        private void dgvAlphabet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvAlphabet.Rows[e.RowIndex].IsNewRow)
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
            stateSource.PosibleChange(ListChangedType.ItemDeleted, this.dgvStates.Rows.IndexOf(e.Row));

            List<DataGridViewRow> removeRows = new List<DataGridViewRow>();
            //Update transitions
            foreach (DataGridViewRow dataRow in this.dgvTransitions.Rows)
            {
                if (dataRow.Cells[0].Value != null && dataRow.Cells[0].Value.Equals(value))
                    removeRows.Add(dataRow);
                else if (dataRow.Cells[1].Value != null && dataRow.Cells[1].Value.Equals(value))
                    removeRows.Add(dataRow);
            }

            foreach (DataGridViewRow dataRow in removeRows)
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

        public abstract string GetTitle();
    }
}
