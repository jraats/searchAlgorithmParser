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
    public partial class FrmImage : Form
    {
        public FrmImage()
        {
            InitializeComponent();
        }

        private void FrmImage_Load(object sender, EventArgs e)
        {

        }

        public void SetPicture(string url)
        {
            this.picture.ImageLocation = url;
        }
    }
}
