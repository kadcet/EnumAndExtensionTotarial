using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumAndExtensionTotarial.Bll.Extensions
{
    public static class Extensions
    {
        public static string? EnumAciklamasiniGetir(this Enum deger)
        {
            if (deger == null) return "";

            var descriptionAttribute = deger.GetType()
                .GetMember(deger.ToString() ?? string.Empty)
                .FirstOrDefault()
                ?.GetCustomAttribute<DescriptionAttribute>();

            return descriptionAttribute?.Description;

        }

        public static int YasHesaplama(this DateTime dogumTarihi)
        {
            return DateTime.Today.Year - dogumTarihi.Year;
        }

        //public static int SayiyaDonustur(this string gelenDeger)
        //{
        //    return Convert.ToInt32(gelenDeger);
        //}
    }
}
