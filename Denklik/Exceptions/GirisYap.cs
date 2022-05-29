using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denklik.Exceptions
{
    public class GirisYap:Exception
    {
        public GirisYap() : base("E posta veya şifre hatalı") {
            MessageBox.Show("E posta veya Şifre hatalı!", "Giriş Hatalı",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class BosGecilemez : Exception
    {
        public BosGecilemez() : base("alan boş gecilemez") {
            MessageBox.Show("Mevcut alanların tamamını doldurmanız gerekmektedir!","Boş Alan", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class OnaySec : Exception
    {
        public OnaySec():base("Onay Durumu Seç")
        {
            MessageBox.Show("Lütfen Onay Durumu Seçiniz", "Onay Durumu",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class TCKontrolleri : Exception
    {
        public TCKontrolleri(string hatamesaji):base("tc de hata var.")
        {
            MessageBox.Show(hatamesaji, "TC HATASI",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class ButonIleriGeri : Exception
    {
        public ButonIleriGeri(string hatamesaji):base("veri çekilirken hata")
        {
            MessageBox.Show(hatamesaji, "veri çekme hatası",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
