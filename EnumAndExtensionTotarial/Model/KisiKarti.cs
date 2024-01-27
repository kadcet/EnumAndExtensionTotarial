using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumAndExtensionTotarial.Model.Enums;

namespace EnumAndExtensionTotarial.Model
{
    public class KisiKarti
    {
        public int KayitNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Email { get; set; }
        public int DogumGun { get; set; }
        public int DogumAyi { get; set; }
        public int DogumYili { get; set; }
        public KartTipi KayitKartTipi { get; set; }
    }
}
