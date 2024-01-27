using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumAndExtensionTotarial.Helper
{
    public class Helper
    {
        public DateTime DogumTarihiYazdir(int gun,int ay,int yil)
        {
            return new DateTime(yil,ay,gun);
        }
    }
}
