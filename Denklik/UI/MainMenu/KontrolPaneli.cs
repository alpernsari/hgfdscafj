using Denklik.BLL.Concrete;
using Denklik.Exceptions;
using Denklik.Models.dbModels;
using Denklik.UI.MainMenu.Butonlar;
using Denklik.UI.UserControls;
using Denklik.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denklik.UI.MainMenu
{
    public partial class KontrolPaneli : Form
    {
        // Button btnYeniKayit;
        UCKontrolPaneli ucKontrolPanel;
        UCYeniKayit ucYeniKayit;
        Form1 GirisEkrani;
        private static tblOkullar _okul;
        private tblDenklik _denklik;
        private tblDenklikSabitler dSabitler;
        private int iKayitSayisi;
        private string AdminYet;
        public static string MudurAd, MudurYardAd, KurumAd/*, _DenklikTarihi, _KomisyonBaskani*/;

        public KontrolPaneli()
        {
            InitializeComponent();
        }
        public void ayarla(Form1 frm)
        {
            GirisEkrani = frm;
            GirisEkrani.btnGirisYap.Click += BtnGirisYap_Click;
            GirisEkrani.txtE_Posta.KeyDown += TxtE_Posta_KeyDown;
            GirisEkrani.txtSifre.KeyDown += TxtSifre_KeyDown;
        }

        private void TxtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnGirisYap_Click(GirisEkrani, new EventArgs());
            }
        }

        private void TxtE_Posta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnGirisYap_Click(GirisEkrani, new EventArgs());
            }
        }


        private void KontrolPaneli_Load(object sender, EventArgs e)
        {
            
            iKayitSayisi = adoAlanVeDalBLL.Count("select TCNO from tblDenklik");
            ucKontrolPanel = new UCKontrolPaneli();
            ucYeniKayit = new UCYeniKayit();
            dSabitler = adoDenklikSabitlerBLL.GetOne();
            MessageBox.Show(dSabitler.DenklikTarihi.ToString() + dSabitler.KomisyonBaskani.ToString());


            pnlKontrolPanel.Controls.Add(ucKontrolPanel);
           

            ucKontrolPanel.btnYeni_Duzeltme.Click += BtnYeni_Duzeltme_Click;
            ucKontrolPanel.btnCikis.Click += BtnCikis_Click;
            ucKontrolPanel.btnDenklikBelgeYazdir.Click += BtnDenklikBelgeYazdir_Click;

            ucYeniKayit.txtKisiSayisi.Text = "1/" + iKayitSayisi.ToString();

            ucYeniKayit.btnKaydet.Click += BtnKaydet_Click;
            ucYeniKayit.btnAnaMenu.Click += BtnAnaMenu_Click;
            ucYeniKayit.btnSil.Click += BtnSil_Click;
            ucYeniKayit.btnIleri.Click += BtnIleri_Click;
            ucYeniKayit.btnGeri.Click += BtnGeri_Click;
            ucYeniKayit.btnSon.Click += BtnSon_Click;
            ucYeniKayit.btnBas.Click += BtnBas_Click;
            ucYeniKayit.btnGuncelle.Click += BtnGuncelle_Click;
            ucYeniKayit.btnYeni.Click += BtnYeni_Click;

            ucYeniKayit.mtxtDogumTarih.KeyUp += MtxtDogumTarih_KeyUp; 
            ucYeniKayit.cmbAlan.SelectedIndexChanged += CmbAlan_SelectedIndexChanged;

            ucYeniKayit.rb1.Click += Rb1_Click;
            ucYeniKayit.rb2.Click += Rb2_Click;
            ucYeniKayit.rb3.Click += Rb3_Click;
            ucYeniKayit.rb4.Click += Rb4_Click;
            ucYeniKayit.rb5.Click += Rb5_Click;
            

            List<tblAlanVeDallar> lAlanlar = new List<tblAlanVeDallar>();
            
            DataTable dt = adoAlanVeDalBLL.GetAll("select distinct alan from alanvedallar");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ucYeniKayit.cmbAlan.Items.Add(dt.Rows[i][0].ToString());
            }
            
            DenklikYaz(1);
            YasDuzenle();

            if (AdminYet == "ADMİN")
            {
                ucKontrolPanel.btnKomisyonBilgiGiris.Visible = false;
            }

           // _denklik.KomisyonBaskani = dSabitler.KomisyonBaskani;
           //_denklik.DenklikTarihi = dSabitler.DenklikTarihi;
        }



        private void BtnYeni_Click(object sender, EventArgs e)
        {
            ucYeniKayit.txtKisiSayisi.Text = " 1/" + iKayitSayisi.ToString();
            ucYeniKayit.mtxtTCNO.Text = "";
            ucYeniKayit.txtDenklikNo.Text = "";
            ucYeniKayit.txtAdSoyad.Text = "";
            ucYeniKayit.cmbAlan.Text = "";
            ucYeniKayit.cmbMeslekDali.Text = "";
            ucYeniKayit.txtBabaAdi.Text = "";
            ucYeniKayit.txtAnneAdi.Text = "";
            ucYeniKayit.txtDogumYeri.Text = "";
            ucYeniKayit.mtxtDogumTarih.Text = "";
            ucYeniKayit.cmbOgrenimDurum.Text = "";
            ucYeniKayit.cmbKanunMaddesi.Text = "";
            ucYeniKayit.mtxtCepTelNo.Text = "";
            ucYeniKayit.rb1.Checked = false;
            ucYeniKayit.rb2.Checked = false;
            ucYeniKayit.rb3.Checked = false;
            ucYeniKayit.rb4.Checked = false;
            ucYeniKayit.rb5.Checked = false;
            ucYeniKayit.cbUstalik.Checked = false;ucYeniKayit.cbKalfalik.Checked= false;
            _denklik = null;

            
            ucYeniKayit.btnKaydet.Location = ucYeniKayit.btnGuncelle.Location;
            ucYeniKayit.btnKaydet.Visible = true;
            ucYeniKayit.btnGuncelle.Visible = false;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            string _OnayDurumu;
            string _TCNo = ucYeniKayit.mtxtTCNO.Text, _DenklikNo = ucYeniKayit.txtDenklikNo.Text,
                _AdiSoyadi = ucYeniKayit.txtAdSoyad.Text, _Alan = ucYeniKayit.cmbAlan.Text,
                _MeslekDali = ucYeniKayit.cmbMeslekDali.Text, _BabaAdi = ucYeniKayit.txtBabaAdi.Text,
                _AnneAdi = ucYeniKayit.txtAnneAdi.Text, _DogumYeri = ucYeniKayit.txtDogumYeri.Text,
                _DogumTarih = ucYeniKayit.mtxtDogumTarih.Text, _OgrenimDurum = ucYeniKayit.cmbOgrenimDurum.Text,
                _KanunMaddesi = ucYeniKayit.cmbKanunMaddesi.Text, _CepTelNo = ucYeniKayit.mtxtCepTelNo.Text;
            int _KalfalikUstalik = 0;

            

            _DogumTarih = clsTextIslemler.TextDuzenle(_DogumTarih);//yaş hesaplama olacak


            if (ucYeniKayit.rb1.Checked == true)
            {
                _OnayDurumu = "Kalfalık sınavlarına girmesi";
                _KalfalikUstalik = 1;
            }
            else if (ucYeniKayit.rb2.Checked == true)
            {
                _OnayDurumu = "Doğrudan kalfalık belgesi düzenlenmesi";
                _KalfalikUstalik = 1;
            }
            else if (ucYeniKayit.rb3.Checked == true)
            {
                _OnayDurumu = "Kalfalık sınavına girmesi, başarılı olması halinde ustalık sınavların alınması";
                _KalfalikUstalik = 1;
            }
            else if (ucYeniKayit.rb4.Checked == true)
            {
                _OnayDurumu = "Ustalık sınavlarına girmesi";
                _KalfalikUstalik = 2;
            }
            else if (ucYeniKayit.rb5.Checked == true)
            {
                _OnayDurumu = "Doğrudan ustalık belgesi düzenlenmesi";
                _KalfalikUstalik = 2;
            }
            else
            {
                throw new OnaySec();
            }

            //dSabitler = adoDenklikSabitlerBLL.GetOne();

            

            string MudurAd = "fethi yaşar", MudurYardAd = "Necdet Sarı", KurumAd = "Erkunt MEM";



            tblDenklik _denk = new tblDenklik();

            _denk.TCNO = _TCNo; _denk.DenklikNo = _DenklikNo; _denk.AdiSoyadi = _AdiSoyadi; _denk.Alan = _Alan;
            _denk.MeslekDali = _MeslekDali; _denk.BabaAdi = _BabaAdi; _denk.AnneAdi = _AnneAdi; _denk.DogumYeri = _DogumYeri;
            _denk.DogumTarihi = _DogumTarih; _denk.OgrenimDurumu = _OgrenimDurum; _denk.DenklikTarihi = dSabitler.DenklikTarihi;
            _denk.KanunMaddesi = _KanunMaddesi; _denk.CepTelefon = _CepTelNo; _denk.KurumAdi = KurumAd; _denk.MudurAdi = MudurAd; _denk.MudurYardAdi = MudurYardAd;
            _denk.KomisyonBaskani = dSabitler.KomisyonBaskani; _denk.OnayMetni = _OnayDurumu; _denk.Ustalik_Kalfalik = _KalfalikUstalik.ToString();

            if (_denk.TCNO != _denklik.TCNO)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set TCNO = '" + _denk.TCNO + "' where ID = " + _denklik.ID);

            }
            if (_denk.DenklikNo != _denklik.DenklikNo)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set DenklikNo = '" + _denk.DenklikNo + "' where ID = " + _denklik.ID);

            }
            if (_denk.AdiSoyadi != _denklik.AdiSoyadi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set AdiSoyadi = '" + _denk.AdiSoyadi + "' where ID = " + _denklik.ID);

            }
            if (_denk.Alan != _denklik.Alan)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set Alan = '" + _denk.Alan + "' where ID = " + _denklik.ID);

            }
            if (_denk.MeslekDali != _denklik.MeslekDali)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set MeslekDali = '" + _denk.MeslekDali + "' where ID = " + _denklik.ID);

            }
            if (_denk.BabaAdi != _denklik.BabaAdi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set BabaAdi = '" + _denk.BabaAdi + "' where ID = " + _denklik.ID);

            }
            if (_denk.AnneAdi != _denklik.AnneAdi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set AnneAdi = '" + _denk.AnneAdi + "' where ID = " + _denklik.ID);

            }
            if (_denk.DogumYeri != _denklik.DogumYeri)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set DogumYeri = '" + _denk.DogumYeri + "' where ID = " + _denklik.ID);

            }
            if (_denk.DogumTarihi != _denklik.DogumTarihi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set DogumTarihi = '" + _denk.DogumTarihi + "' where ID = " + _denklik.ID);

            }
            if (_denk.OgrenimDurumu != _denklik.OgrenimDurumu)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set OgrenimDurumu = '" + _denk.OgrenimDurumu + "' where ID = " + _denklik.ID);

            }
            if (_denk.DenklikTarihi != _denklik.DenklikTarihi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set DenklikTarihi = '" + _denk.DenklikTarihi + "' where ID = " + _denklik.ID);

            }
            if (_denk.KanunMaddesi != _denklik.KanunMaddesi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set KanunMaddesi = '" + _denk.KanunMaddesi + "' where ID = " + _denklik.ID);

            }
            if (_denk.CepTelefon != _denklik.CepTelefon)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set CepTelefon = '" + _denk.CepTelefon + "' where ID = " + _denklik.ID);

            }
            if (_denk.KurumAdi != _denklik.KurumAdi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set KurumAdi = '" + _denk.KurumAdi + "' where ID = " + _denklik.ID);
            }
            if (_denk.MudurAdi != _denklik.MudurAdi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set MudurAdi = '" + _denk.MudurAdi + "' where ID = " + _denklik.ID);

            }
            if (_denk.MudurYardAdi != _denklik.MudurYardAdi)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set MudurYardAdi = '" + _denk.MudurYardAdi + "' where ID = " + _denklik.ID);

            }
            if (_denk.KomisyonBaskani != _denklik.KomisyonBaskani)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set KomisyonBaskani = '" + _denk.KomisyonBaskani + "' where ID = " + _denklik.ID);

            }
            if (_denk.OnayMetni != _denklik.OnayMetni)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set OnayMetni = '" + _denk.OnayMetni + "' where ID = " + _denklik.ID);

            }
            if (_denk.Ustalik_Kalfalik != _denklik.Ustalik_Kalfalik)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("update tblDenklik set Ustalik_Kalfalik = '" + _denk.Ustalik_Kalfalik + "' where ID = " + _denklik.ID);

            }

            MessageBox.Show("Kayıt güncellendi!", "Güncellendi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }


        private void BtnBas_Click(object sender, EventArgs e)
        {
            DenklikYaz(1);
            ucYeniKayit.txtKisiSayisi.Text = 1.ToString() + "/" +
                iKayitSayisi.ToString();

            ucYeniKayit.btnGuncelle.Visible = true;
            ucYeniKayit.btnKaydet.Visible = false;
        }

        private void BtnSon_Click(object sender, EventArgs e)
        {
            DenklikYaz(iKayitSayisi);
            ucYeniKayit.txtKisiSayisi.Text = iKayitSayisi.ToString() + "/" +
                iKayitSayisi.ToString();

            ucYeniKayit.btnGuncelle.Visible = true;
            ucYeniKayit.btnKaydet.Visible = false;
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            int iRow;
            string sRow = ucYeniKayit.txtKisiSayisi.Text;
            iRow = int.Parse(sRow.Substring(0, sRow.IndexOf("/")))-1;
            if (iRow <= 0)
            {
                iRow = iKayitSayisi;
                DenklikYaz(iRow);
            }
            DenklikYaz(iRow);
            YasDuzenle();
            ucYeniKayit.txtKisiSayisi.Text = iRow.ToString() + "/" +
                iKayitSayisi.ToString();

            ucYeniKayit.btnGuncelle.Visible = true;
            ucYeniKayit.btnKaydet.Visible = false;
        }

        private void BtnIleri_Click(object sender, EventArgs e)
        {
            int iRow;
            string sRow = ucYeniKayit.txtKisiSayisi.Text;
            iRow = int.Parse(sRow.Substring(0, sRow.IndexOf("/")))+1;
           
            if (iRow > iKayitSayisi)
            {
                iRow = 1;
                DenklikYaz(iRow);
            }
                DenklikYaz(iRow);
            YasDuzenle();

            ucYeniKayit.txtKisiSayisi.Text = iRow.ToString() + "/" + 
                iKayitSayisi.ToString();

            ucYeniKayit.btnGuncelle.Visible = true;
            ucYeniKayit.btnKaydet.Visible = false;
        }

     
        private void CmbAlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucYeniKayit.cmbMeslekDali.Items.Clear();
            DataTable dt = adoAlanVeDalBLL.GetAll("select distinct dal from alanvedallar where alan= '"+ucYeniKayit.cmbAlan.Text+"'");
            
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ucYeniKayit.cmbMeslekDali.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void DenklikYaz(int iRow)
        {
            
            _denklik = adoDenklikBLL.GetOne("select tablo.* from (select ROW_NUMBER() over(order by ID) indexer," +
                "* from tblDenklik) tablo where tablo.indexer ="+iRow.ToString());
            ucYeniKayit.mtxtTCNO.Text = _denklik.TCNO;
            ucYeniKayit.txtDenklikNo.Text = _denklik.DenklikNo;
            ucYeniKayit.txtAdSoyad.Text = _denklik.AdiSoyadi;
            ucYeniKayit.cmbAlan.Text = _denklik.Alan;
            ucYeniKayit.cmbMeslekDali.Text = _denklik.MeslekDali;
            ucYeniKayit.txtBabaAdi.Text = _denklik.BabaAdi;
            ucYeniKayit.txtAnneAdi.Text = _denklik.AnneAdi;
            ucYeniKayit.mtxtDogumTarih.Text = _denklik.DogumTarihi;
            ucYeniKayit.txtDogumYeri.Text = _denklik.DogumYeri;
            ucYeniKayit.cmbOgrenimDurum.Text = _denklik.OgrenimDurumu;
            ucYeniKayit.cmbKanunMaddesi.Text = _denklik.KanunMaddesi;
            ucYeniKayit.mtxtCepTelNo.Text = _denklik.CepTelefon;
            switch (_denklik.OnayMetni)
            {
                case "Kalfalık sınavlarına girmesi":
                    ucYeniKayit.rb1.Checked = true;
                    ucYeniKayit.cbKalfalik.Checked = true;
                    ucYeniKayit.cbUstalik.Checked = false;
                    break;
                case "Doğrudan kalfalık belgesi düzenlenmesi":
                    ucYeniKayit.rb2.Checked = true;
                    ucYeniKayit.cbKalfalik.Checked = true;
                    ucYeniKayit.cbUstalik.Checked = false;
                    break;
                case "Kalfalık sınavına girmesi, başarılı olması halinde ustalık sınavların alınması":
                    ucYeniKayit.rb3.Checked = true;
                    ucYeniKayit.cbKalfalik.Checked = true;
                    ucYeniKayit.cbUstalik.Checked = false;
                    break;
                case "Ustalık sınavlarına girmesi":
                    ucYeniKayit.rb4.Checked = true;
                    ucYeniKayit.cbUstalik.Checked = true;
                    ucYeniKayit.cbKalfalik.Checked = false;
                    break;
                case "Doğrudan ustalık belgesi düzenlenmesi":
                    ucYeniKayit.rb5.Checked = true;
                    ucYeniKayit.cbUstalik.Checked = true;
                    ucYeniKayit.cbKalfalik.Checked = false;
                    break;
            }
        }
        private void MtxtDogumTarih_KeyUp(object sender, KeyEventArgs e)
        {
            YasDuzenle();
        }

        private void YasDuzenle()
        {
            if (ucYeniKayit.mtxtDogumTarih.Text.Length % 10 == 0)
            {
                string[] sDizi;
                string met = clsTextIslemler.YasHesapla(ucYeniKayit.mtxtDogumTarih.Text);
                sDizi = met.Split('/');
                ucYeniKayit.lblYas.Text = sDizi[0];
                ucYeniKayit.lblYasDurumu.Text = sDizi[1];
                if (sDizi[1] == "Yaşı Uygun")
                {
                    ucYeniKayit.lblYasDurumu.ForeColor = Color.Green;
                    ucYeniKayit.btnKaydet.Enabled = true;
                }

                else
                {
                    ucYeniKayit.lblYasDurumu.ForeColor = Color.Red;
                    ucYeniKayit.btnKaydet.Enabled = false;
                }
            }
            else
                ucYeniKayit.lblYas.Text = "__";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_denklik.TCNO.ToString());

            

            DialogResult dr;
            dr = MessageBox.Show("Seçili kayıtı silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo
                , MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                adoDenklikBLL.UpdateOrDeleteBLL("delete from tblDenklik where ID= " +_denklik.ID.ToString());
                iKayitSayisi--;
                ucYeniKayit.txtKisiSayisi.Text = iKayitSayisi.ToString() + "/" + iKayitSayisi.ToString();
            }
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            _okul = new tblOkullar();

            _okul = adoOkullarBLL.GetOne(GirisEkrani.txtE_Posta.Text, GirisEkrani.txtSifre.Text);
            AdminYet = _okul.Yetki;
            MudurAd = _okul.MudurAdSoyad;
            MudurYardAd = _okul.MudurYardAdSoyad;
            KurumAd = _okul.OkulAdi;
            if (_okul.ID != 0)
            {
                this.Show();
                GirisEkrani.Hide();
            }
            
        }

        private void BtnDenklikBelgeYazdir_Click(object sender, EventArgs e)
        {
            DenklikBelgeYazdir db = new DenklikBelgeYazdir();
            db.Show();
        }

        private void Rb5_Click(object sender, EventArgs e)
        {
            ucYeniKayit.cbKalfalik.Checked = false;
            ucYeniKayit.cbUstalik.Checked = true;
        }

        private void Rb4_Click(object sender, EventArgs e)
        {
            ucYeniKayit.cbKalfalik.Checked = false;
            ucYeniKayit.cbUstalik.Checked = true;
        }

        private void Rb3_Click(object sender, EventArgs e)
        {

            ucYeniKayit.cbKalfalik.Checked = true;
            ucYeniKayit.cbUstalik.Checked = false;
        }

        private void Rb2_Click(object sender, EventArgs e)
        {

            ucYeniKayit.cbKalfalik.Checked = true;
            ucYeniKayit.cbUstalik.Checked = false;
        }

        private void Rb1_Click(object sender, EventArgs e)
        {

            ucYeniKayit.cbKalfalik.Checked = true;
            ucYeniKayit.cbUstalik.Checked = false;
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAnaMenu_Click(object sender, EventArgs e)
        {
            pnlKontrolPanel.Controls.Clear();
            pnlKontrolPanel.Controls.Add(ucKontrolPanel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string _OnayDurumu;
                string _TCNo = ucYeniKayit.mtxtTCNO.Text, _DenklikNo = ucYeniKayit.txtDenklikNo.Text,
                    _AdiSoyadi = ucYeniKayit.txtAdSoyad.Text, _Alan = ucYeniKayit.cmbAlan.Text,
                    _MeslekDali = ucYeniKayit.cmbMeslekDali.Text, _BabaAdi = ucYeniKayit.txtBabaAdi.Text,
                    _AnneAdi = ucYeniKayit.txtAnneAdi.Text, _DogumYeri = ucYeniKayit.txtDogumYeri.Text,
                    _DogumTarih = ucYeniKayit.mtxtDogumTarih.Text, _OgrenimDurum = ucYeniKayit.cmbOgrenimDurum.Text,
                    _KanunMaddesi = ucYeniKayit.cmbKanunMaddesi.Text,_CepTelNo = ucYeniKayit.mtxtCepTelNo.Text;
                int _KalfalikUstalik = 0;
            
               // tblDenklikSabitler dSabitler = new tblDenklikSabitler();

                _DogumTarih = clsTextIslemler.TextDuzenle(_DogumTarih);//yaş hesaplama olacak
                

                if (ucYeniKayit.rb1.Checked == true)
                {
                    _OnayDurumu = "Kalfalık sınavlarına girmesi";
                    _KalfalikUstalik = 1;
                }
                else if (ucYeniKayit.rb2.Checked == true) 
                {
                    _OnayDurumu = "Doğrudan kalfalık belgesi düzenlenmesi";
                    _KalfalikUstalik = 1;
                }
                else if (ucYeniKayit.rb3.Checked == true) 
                {
                    _OnayDurumu = "Kalfalık sınavına girmesi, başarılı olması halinde ustalık sınavların alınması";
                    _KalfalikUstalik = 1;
                }
                else if (ucYeniKayit.rb4.Checked == true) 
                {
                    _OnayDurumu = "Ustalık sınavlarına girmesi";
                    _KalfalikUstalik = 2;
                }
                else if (ucYeniKayit.rb5.Checked == true) 
                {
                   _OnayDurumu = "Doğrudan ustalık belgesi düzenlenmesi";
                    _KalfalikUstalik = 2;
                }
                else {
                    throw new OnaySec();
                }

                //dSabitler = adoDenklikSabitlerBLL.GetOne();


                //string MudurAd="fethi yaşar", MudurYardAd="Necdet Sarı", KurumAd="Erkunt MEM";

                
                clsTextIslemler.TextKontrolEt(_TCNo, _DenklikNo, _AdiSoyadi, _Alan, _MeslekDali, _BabaAdi, _AnneAdi
                    , _DogumYeri, _DogumTarih, _OgrenimDurum, _KanunMaddesi, _CepTelNo, dSabitler.DenklikTarihi.ToString(), 
                    dSabitler.KomisyonBaskani,MudurAd, MudurYardAd, KurumAd);

                adoDenklikBLL.NewLine("tblDenklik", _TCNo, _DenklikNo, _AdiSoyadi, _Alan, _MeslekDali, _BabaAdi,
                    _AnneAdi, _DogumYeri, _DogumTarih, _OgrenimDurum, dSabitler.DenklikTarihi.ToString(), _KanunMaddesi, _CepTelNo, KurumAd,
                    MudurAd, MudurYardAd, dSabitler.KomisyonBaskani.ToString(), _OnayDurumu, _KalfalikUstalik);
              
                MessageBox.Show("Kayıt Başarıyla Eklendi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                iKayitSayisi++;
                ucYeniKayit.txtKisiSayisi.Text = iKayitSayisi.ToString() + "/" + iKayitSayisi.ToString();


            }
            catch (Exception ex){/*MessageBox.Show(ex.Message);*/} 
            
        }

        private void BtnYeni_Duzeltme_Click(object sender, EventArgs e)
        {
            pnlKontrolPanel.Controls.Clear();
            pnlKontrolPanel.Controls.Add(ucYeniKayit);
        }
    }
}
