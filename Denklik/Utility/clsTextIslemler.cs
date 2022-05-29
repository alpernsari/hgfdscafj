using Denklik.BLL.Concrete;
using Denklik.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denklik.Utility
{
    public static class clsTextIslemler
    {
        public static string TextDuzenle(string metin)
        {
            string[] dizi;

            dizi = metin.Split('/');
            metin = "";
            foreach (var item in dizi)
            {
                metin += item;
            }
            return metin;
        }

        public static void TextKontrolEt(params string[] a)
        {
            foreach (string item in a)
            {
                if (item =="")
                {
                    throw new BosGecilemez();
                }
            }

            if (a[0].Length!=11)
            {
                throw new TCKontrolleri("TC KİMLİK NUMARASINI EKSİK GİRDİNİZ!");
            }
            else
            {
                adoDenklikBLL.GetAllTC(a[0]);
            }

        }

        public static string YasHesapla(string sMetin)
        {
            string[] dizi;
            int iBuGun, iBuAy, iBuYil;
            int iKisiGun, iKisiAy, iKisiYil;
            int iFarkGun, iFarkAy, iFarkYil;

            iBuGun = DateTime.Now.Day; iBuAy = DateTime.Now.Month;
            iBuYil = DateTime.Now.Year;

            dizi = sMetin.Split('/');
            sMetin = "";
            iKisiGun = int.Parse(dizi[0]);
            iKisiAy = int.Parse(dizi[1]);
            iKisiYil = int.Parse(dizi[2]);

            if (iBuGun < iKisiGun)
            {
                iBuGun += DateTime.DaysInMonth(iBuYil, iBuAy);
                iFarkGun = iBuGun - iKisiGun;
                iBuAy--;
                if (iBuAy < iKisiAy)
                {
                    iBuAy += 12;
                    iBuYil--;
                    iFarkAy = iBuAy - iKisiAy;
                    iFarkYil = iBuYil - iKisiYil;
                }
                else
                {
                    iFarkAy = iBuAy - iKisiAy;
                    iFarkYil = iBuYil - iKisiYil;
                }
            }
            else
            {
                iFarkGun = iBuGun - iKisiGun;
                if (iBuAy < iKisiAy)
                {
                    iBuAy += 12;
                    iBuYil--;
                    iFarkAy = iBuAy - iKisiAy;
                    iFarkYil = iBuYil - iKisiYil;
                }
                else
                {
                    iFarkAy = iBuAy - iKisiAy;
                    iFarkYil = iBuYil - iKisiYil;
                }

                
            }
            string sUygunluk = "Yaşı Uygun Değil";
            if (iFarkYil>=22)
            {
                sUygunluk = "Yaşı Uygun";
            }
            if (iFarkYil >= 0||iFarkYil<=100)
            {
                sMetin = iFarkYil.ToString() + " yıl " + iFarkAy.ToString() +
                    " ay " + iFarkGun.ToString() + " gun " + (iFarkYil * 365 + iFarkAy * 12 + iFarkGun).ToString() + " Gün" +
                    "/" + sUygunluk;
            }
            else
                sMetin = "Yaş yanlış girildi" +"/"+ sUygunluk;

            return sMetin;
        }
    }
}
