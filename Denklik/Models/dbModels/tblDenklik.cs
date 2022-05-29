using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denklik.Models.dbModels
{
    public class tblDenklik
    {
        public int ID { get; set; }
        public string TCNO { get; set; }
        public string DenklikNo { get; set; }
        public string AdiSoyadi { get; set; }
        public string Alan { get; set; }
        public string MeslekDali { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public string DogumYeri { get; set; }
        public string DogumTarihi { get; set; }
        public string OgrenimDurumu { get; set; }
        public string DenklikTarihi { get; set; }
        public string KanunMaddesi { get; set; }
        public string CepTelefon { get; set; }
        public string KurumAdi { get; set; }
        public string MudurAdi { get; set; }
        public string MudurYardAdi { get; set; }
        public string KomisyonBaskani { get; set; }
        public string OnayMetni { get; set; }
        public string Ustalik_Kalfalik { get; set; }
    }
}
