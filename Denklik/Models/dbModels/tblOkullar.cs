using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denklik.Models.dbModels
{
    public class tblOkullar
    {
        public int ID { get; set; }
        public string OkulAdi { get; set; }
        public string OkulE_Posta { get; set; }
        public string OkulSifre { get; set; }
        public string MudurAdSoyad { get; set; }
        public string MudurYardAdSoyad { get; set; }
        public string Yetki{ get; set; }

    }
}
