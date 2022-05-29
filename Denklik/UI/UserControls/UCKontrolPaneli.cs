using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denklik.UI.UserControls
{
    public partial class UCKontrolPaneli : UserControl
    {
        public UCKontrolPaneli()
        {
            InitializeComponent();
        }

        private void UCKontrolPaneli_Load(object sender, EventArgs e)
        {
            this.Location = new Point(225,0);
        }
    }
}
