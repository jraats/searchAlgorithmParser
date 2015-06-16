using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gui
{
    public class DataTableColumnSource<T> : IBindingList
    {
        public event ListChangedEventHandler ListChanged;
        public DataGridView dataTable { get; set; }
        public int column { get; set; }
        public T[] additional;


        public DataTableColumnSource(ref DataGridView dataTable, int column) :this(ref dataTable, column, new T[0])
        {

        }
        public DataTableColumnSource(ref DataGridView dataTable, int column, T[] additional)
        {
            this.dataTable = dataTable;
            this.column = column;
            this.additional = additional;
        }

        public void PosibleChange(ListChangedType type, int index)
        {
            if (ListChanged != null)
            {
                ListChanged(this, new ListChangedEventArgs(type, index));
                
            }
        }

        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public object AddNew()
        {
            return new Comboboxitem<T>(default(T), -1); ;
        }

        public bool AllowEdit
        {
            get { throw new NotImplementedException(); }
        }

        public bool AllowNew
        {
            get { return true; }
        }

        public bool AllowRemove
        {
            get { throw new NotImplementedException(); }
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotImplementedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted
        {
            get { throw new NotImplementedException(); }
        }

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotImplementedException();
        }

        public void RemoveSort()
        {
            throw new NotImplementedException();
        }

        public ListSortDirection SortDirection
        {
            get { throw new NotImplementedException(); }
        }

        public PropertyDescriptor SortProperty
        {
            get { throw new NotImplementedException(); }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { return false; }
        }

        public bool SupportsSorting
        {
            get { return false; }
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get
            {
                if (index < this.additional.Length)
                    return this.additional[index];

                index -= additional.Length;

                if (this.dataTable.Rows[index].Cells[this.column].Value == null)
                    return null;

                T w =(T) Convert.ChangeType(this.dataTable.Rows[index].Cells[this.column].Value, typeof(T));
                return w;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                return this.dataTable.Rows.Count -1 + additional.Length;
            }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public T[] GetTableArray()
        {
            List<T> returnList = new List<T>();
            int c = Count;
            for(int i = this.additional.Length; i < c; i++)
                returnList.Add((T)this[i]);
            return returnList.ToArray();
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            int c = Count;
            for (int i = 0; i < c; i++)
                yield return this[i];
        }
    }
}
