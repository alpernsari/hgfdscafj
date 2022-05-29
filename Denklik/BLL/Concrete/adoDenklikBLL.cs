using Denklik.DLL.Concrete;
using Denklik.Exceptions;
using Denklik.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denklik.BLL.Concrete
{
    public static class adoDenklikBLL
    {
        private static adoDenklikDLL _Denklik;
        private static DataTable dt;
        

        public static void GetAllTC(string TC)
        {
            _Denklik = new adoDenklikDLL();

            dt = _Denklik.GetAllTC();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (TC == dt.Rows[i][0].ToString())
                {
                    throw new TCKontrolleri("BU TC İÇİN KAYIT MEVCUT");
                }
            }
        }

        public static void NewLine(string tblAdi, params object[] kolonlar)
        {
            adoDenklikDLL _denklik = new adoDenklikDLL();
            _denklik.NewLine(tblAdi, kolonlar);
        }
        
        public static tblDenklik GetOne(string sCom)
        {
            adoDenklikDLL _denklikDLL = new adoDenklikDLL();
            tblDenklik _denklik = new tblDenklik();
            //sCom += Id.ToString();
            dt = _denklikDLL.GetOne(sCom);
            try
            {
                if (dt.Rows.Count == 0)
                {
                    throw new ButonIleriGeri("veri çekilirken hata oluştu");
                }
                else
                {
                    _denklik.ID = (int)dt.Rows[0][1];
                    _denklik.TCNO = dt.Rows[0][2].ToString();
                    _denklik.DenklikNo = dt.Rows[0][3].ToString();
                    _denklik.AdiSoyadi = dt.Rows[0][4].ToString();
                    _denklik.Alan = dt.Rows[0][5].ToString();
                    _denklik.MeslekDali = dt.Rows[0][6].ToString();
                    _denklik.BabaAdi = dt.Rows[0][7].ToString();
                    _denklik.AnneAdi = dt.Rows[0][8].ToString();
                    _denklik.DogumYeri= dt.Rows[0][9].ToString();
                    _denklik.DogumTarihi= dt.Rows[0][10].ToString();
                    _denklik.OgrenimDurumu= dt.Rows[0][11].ToString();
                    _denklik.DenklikTarihi= dt.Rows[0][12].ToString();
                    _denklik.KanunMaddesi= dt.Rows[0][13].ToString();
                    _denklik.CepTelefon= dt.Rows[0][14].ToString();
                    _denklik.KurumAdi= dt.Rows[0][15].ToString();
                    _denklik.MudurAdi= dt.Rows[0][16].ToString();
                    _denklik.MudurYardAdi= dt.Rows[0][17].ToString();
                    _denklik.KomisyonBaskani= dt.Rows[0][18].ToString();
                    _denklik.OnayMetni= dt.Rows[0][19].ToString();
                    _denklik.Ustalik_Kalfalik= dt.Rows[0][20].ToString();
                }
            }
            catch (Exception) { }

            return _denklik;
        }

        public static void UpdateOrDeleteBLL(string sCom)
        {
            _Denklik = new adoDenklikDLL();
            _Denklik.UpdateOrDelete(sCom);
        }

    }
}
