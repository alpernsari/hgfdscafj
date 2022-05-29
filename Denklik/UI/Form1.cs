using Denklik.BLL.Concrete;
using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Denklik.UI.MainMenu;
using Denklik.UI.UserControls;
using Denklik.Models.dbModels;

namespace Denklik
{
    public partial class Form1 : Form
    {
        public static tblOkullar _denklik;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            KontrolPaneli kp = new KontrolPaneli();
            kp.ayarla(this);
        }

       
    }
}
