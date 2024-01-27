

using EnumAndExtensionTotarial.Bll.Extensions;
using EnumAndExtensionTotarial.Helper;
using EnumAndExtensionTotarial.Model;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        //VeriTabaniBaglanti(VeriTabaniTipleri.Mysql);
        //KayitOlustur(HesapKodlari.AlinanCekler,FaturaTipleri.Alis);
        KisiKayitlari();
    }

    private enum VeriTabaniTipleri
    {
        Mysql,
        Mssql,
        Oracle
    }


    private static void VeriTabaniBaglanti(VeriTabaniTipleri veriTabaniTipleri)
    {
        var connectionString = "";

        switch (veriTabaniTipleri)
        {
            case VeriTabaniTipleri.Mysql:
                connectionString = "Mysql e bağlantı yapıldı";
                break;
            case VeriTabaniTipleri.Mssql:
                connectionString = "Mssql e bağlantı yapıldı";
                break;
            case VeriTabaniTipleri.Oracle:
                connectionString = "Oracle e bağlantı yapıldı";
                break;

        }

        Console.WriteLine(connectionString);

    }

    private enum HesapKodlari
    {
        Kasa = 100,
        Banka = 102,
        AlinanCekler = 101
    }

    private enum FaturaTipleri
    {
        [Description("Alış Faturaları")]
        Alis,

        [Description("Satış Faturaları")]
        Satis,

        [Description("Hizmet Faturaları")]
        Hizmet
    }

    private static void KayitOlustur(HesapKodlari hesap, FaturaTipleri faturaTipi)
    {
        Console.WriteLine(hesap);
        Console.WriteLine(Convert.ToInt32(hesap));
        Console.WriteLine(faturaTipi.EnumAciklamasiniGetir());
        //Console.Write("sss".SayiyaDonustur());
    }

    private static void KisiKayitlari()
    {
        

        try
        {
            var kisilerTablosu = new List<KisiKarti>
        {
           new KisiKarti {KayitNo=1, Ad="Umut", Soyad="Ergün", Adres="Bursa", DogumGun=20, DogumAyi=9,DogumYili=1983,Email="abc@mail.com", TelefonNo="0506 591 9890",KayitKartTipi=Enums.KartTipi.Aile},
            new KisiKarti {KayitNo=2, Ad="Kadir", Soyad="Çetin", Adres="Bursa", DogumGun=10, DogumAyi=10,DogumYili=1987,Email="kadir@mail.com", TelefonNo="0 507 123 9890",KayitKartTipi=Enums.KartTipi.Diger },
            new KisiKarti {KayitNo=3, Ad="Ahmet", Soyad="Uçar", Adres="İstanbul", DogumGun=5, DogumAyi=2,DogumYili=1990,Email="ahmet@mail.com", TelefonNo=" 0532 321 76 47",KayitKartTipi=Enums.KartTipi.IsArkadaslari },
            new KisiKarti {KayitNo=4, Ad="Mehmet", Soyad="Kaçar", Adres="Ankara", DogumGun=10, DogumAyi=5,DogumYili=1992,Email="mehmet@mail.com", TelefonNo="0531 567 4132",KayitKartTipi=Enums.KartTipi.IsArkadaslari },
            new KisiKarti {KayitNo=5, Ad="Veli", Soyad="Yilmaz", Adres="Ankara", DogumGun=15, DogumAyi=7,DogumYili=1985,Email="veli@mail.com", TelefonNo="05426218524",KayitKartTipi=Enums.KartTipi.IsArkadaslari },
            new KisiKarti {KayitNo=6, Ad="Vural", Soyad="Kaya", Adres="Kocaeli", DogumGun=7, DogumAyi=11,DogumYili=1982,Email="vural@mail.com", TelefonNo="533751 2895",KayitKartTipi=Enums.KartTipi.OkulArkadaslari }
        };

            Console.WriteLine("Hangi Kayıt no getirilsin");
            var GirilenKayitNoInt = Convert.ToInt32(Console.ReadLine());

            var kisiKarti = kisilerTablosu.Where(x => x.KayitNo == GirilenKayitNoInt).FirstOrDefault();
            Console.WriteLine($" Girilen Kayıt No: {kisiKarti.KayitNo} Ad: {kisiKarti.Ad}");

            Console.WriteLine("Hangi İller getirilsin");
            var girilenIl = Console.ReadLine();

            var illereGoreDeger = kisilerTablosu.Where(x => x.Adres == girilenIl).ToList();
            Console.WriteLine($"İllere Göre Bulunan  Kayıt Sayısı : {illereGoreDeger.Count()}");

            var hlp = new Helper();

            foreach (var item in illereGoreDeger)
            {
                var dogumTarihi = hlp.DogumTarihiYazdir(item.DogumGun, item.DogumAyi, item.DogumYili);

                Console.WriteLine($"Ad: {item.Ad} {item.Soyad} Doğum Tarihi: {dogumTarihi} Yaş:{dogumTarihi.YasHesaplama()}");
            }

            Console.WriteLine("Kaç yaş üstü gelsin");
            var gelenYas=Convert.ToInt32(Console.ReadLine());
            var yasaGore=kisilerTablosu.ToList();
            foreach (var item in yasaGore)
            {
                var dogumTarihi = hlp.DogumTarihiYazdir(item.DogumGun, item.DogumAyi, item.DogumYili);
                if (dogumTarihi.YasHesaplama() > gelenYas)
                {
                    Console.WriteLine(item.Ad);
                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine("Hata oldu");
        }

    }


}
