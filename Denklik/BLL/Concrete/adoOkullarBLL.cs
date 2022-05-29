using Denklik.DLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Denklik.Models.dbModels;
using System.Windows.Forms;
using Denklik.Exceptions;

namespace Denklik.BLL.Concrete
{
    public static class adoOkullarBLL
    {
        
        private static DataTable dt;
        private static tblOkullar _okul;


        public static tblOkullar GetOne(string E_Posta,string Sifre)
        {
            adoOkullarDLL _okulDLL= new adoOkullarDLL();
            _okul = new tblOkullar();
            dt = _okulDLL.GetOne(E_Posta, Sifre);

            try
            {
                if (dt.Rows.Count==0)
                {
                    throw new GirisYap();
                }
                else
                {
                    _okul.ID = (int)dt.Rows[0][0];
                    _okul.OkulAdi = dt.Rows[0][1].ToString();
                    _okul.OkulE_Posta = dt.Rows[0][2].ToString();
                    _okul.OkulSifre = dt.Rows[0][3].ToString();
                    _okul.MudurAdSoyad = dt.Rows[0][4].ToString();
                    _okul.MudurYardAdSoyad = dt.Rows[0][5].ToString();
                    _okul.Yetki = dt.Rows[0][6].ToString();
                }
            }
            catch (Exception){}
            

            return _okul;
        }

        public static DataTable GetAll()
        {
            adoOkullarDLL _denklik = new adoOkullarDLL();
            return _denklik.GetAll();
        }

    }
}
