using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui
{
    public class Comboboxitem<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [DisplayName("displayName")]
        public T displayName { get; set; }
        public int valueName { get; set; }
        public Comboboxitem()
        {
            //this.displayName = displayName;
            //this.valueName = valueName;
        }

        public Comboboxitem(T displayName, int valueName)
        {
            this.displayName = displayName;
            this.valueName = valueName;
        }

        public void Changed()
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs("displayName"));
        }

        public override string ToString()
        {
            return displayName.ToString();
        }
    }
}
