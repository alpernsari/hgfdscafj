using Denklik.BLL.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Denklik.Models.dbModels;

namespace Denklik.UI.MainMenu.Butonlar
{
    public partial class DenklikBelgeYazdir : Form
    {
        int iKayitSayisi;
        tblDenklik _denklik;
        private ReportParameter[] rp = new ReportParameter[8];
        public DenklikBelgeYazdir()
        {
            InitializeComponent();
        }

        private void DenklikBelgeYazdir_Load(object sender, EventArgs e)
        {
            iKayitSayisi = adoAlanVeDalBLL.Count("select TCNO from tblDenklik");
            textBox1.Text = "1/" + iKayitSayisi.ToString();
            this.reportViewer1.RefreshReport();

            _denklik = adoDenklikBLL.GetOne("select tablo.* from (select ROW_NUMBER() over(order by ID) indexer," +
            "* from tblDenklik) tablo where tablo.indexer =" + 1.ToString());


            rp[0] = new ReportParameter("adisoyadi", _denklik.AdiSoyadi.ToString());
            rp[1] = new ReportParameter("alan", _denklik.Alan.ToString());
            rp[2] = new ReportParameter("dal", _denklik.MeslekDali.ToString());
            rp[3] = new ReportParameter("MudurYrd", KontrolPaneli.MudurYardAd.ToString());
            rp[4] = new ReportParameter("tcno", _denklik.TCNO.ToString());
            rp[5] = new ReportParameter("Mudur", KontrolPaneli.MudurAd.ToString());
            rp[6] = new ReportParameter("KomisyonBaskani", _denklik.KomisyonBaskani.ToString());
            rp[7] = new ReportParameter("OnayDurum", _denklik.OnayMetni.ToString());

            this.reportViewer1.LocalReport.SetParameters(rp);
            this.reportViewer1.RefreshReport();
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            int iRow;
            string sRow = textBox1.Text;
            iRow = int.Parse(sRow.Substring(0, sRow.IndexOf("/"))) + 1;

            if (iRow > iKayitSayisi)
            {
                iRow = 1;
               
            }
            textBox1.Text = iRow.ToString() + "/" +
                iKayitSayisi.ToString();

            _denklik = adoDenklikBLL.GetOne("select tablo.* from (select ROW_NUMBER() over(order by ID) indexer," +
                        "* from tblDenklik) tablo where tablo.indexer =" + iRow.ToString());

           
            rp[0] = new ReportParameter("adisoyadi", _denklik.AdiSoyadi.ToString());
            rp[1] = new ReportParameter("alan", _denklik.Alan.ToString());
            rp[2] = new ReportParameter("dal", _denklik.MeslekDali.ToString());
            rp[3] = new ReportParameter("MudurYrd", KontrolPaneli.MudurYardAd.ToString());
            rp[4] = new ReportParameter("tcno", _denklik.TCNO.ToString());
            rp[5] = new ReportParameter("Mudur", KontrolPaneli.MudurAd.ToString());
            rp[6] = new ReportParameter("KomisyonBaskani", _denklik.KomisyonBaskani.ToString());
            rp[7] = new ReportParameter("OnayDurum", _denklik.OnayMetni.ToString());
            
            this.reportViewer1.LocalReport.SetParameters(rp);
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iRow;
            string sRow = textBox1.Text;
            iRow = int.Parse(sRow.Substring(0, sRow.IndexOf("/"))) - 1;
            if (iRow <= 0)
            {
                iRow = iKayitSayisi;
            }
            textBox1.Text = iRow.ToString() + "/" +
                iKayitSayisi.ToString();

            _denklik = adoDenklikBLL.GetOne("select tablo.* from (select ROW_NUMBER() over(order by ID) indexer," +
            "* from tblDenklik) tablo where tablo.indexer =" + iRow.ToString());

            
            rp[0] = new ReportParameter("adisoyadi", _denklik.AdiSoyadi.ToString());
            rp[1] = new ReportParameter("alan", _denklik.Alan.ToString());
            rp[2] = new ReportParameter("dal", _denklik.MeslekDali.ToString());
            rp[3] = new ReportParameter("MudurYrd", KontrolPaneli.MudurYardAd.ToString());
            rp[4] = new ReportParameter("tcno", _denklik.TCNO.ToString());
            rp[5] = new ReportParameter("Mudur", KontrolPaneli.MudurAd.ToString());
            rp[6] = new ReportParameter("KomisyonBaskani", _denklik.KomisyonBaskani.ToString());
            rp[7] = new ReportParameter("OnayDurum", _denklik.OnayMetni.ToString());

            this.reportViewer1.LocalReport.SetParameters(rp);
            this.reportViewer1.RefreshReport();
        }
    }
}
