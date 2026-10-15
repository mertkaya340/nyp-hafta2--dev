using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var ekipmanlar = new List<Ekipman>
        {
            new Ekipman("LAB-001", "Kamera"),
            new Ekipman("LAB-002", "Mikrofon"),
            new Ekipman("LAB-003", "Elektronik kit")
        };

        var ogrenciler = new List<Ogrenci>
        {
            new Ogrenci("1001", "Örnek Öğrenci A"),
            new Ogrenci("1002", "Örnek Öğrenci B")
        };

        while (true)
        {
            Console.WriteLine("\n1 Listele | 2 Ödünç ver | 3 İade al | 4 Müsait ekipmanlar | 0 Çıkış");
            Console.Write("Seçim: ");
            string? secim = Console.ReadLine();
            if (secim == null)
                return;

            switch (secim.Trim())
            {
                case "1":
                    Listele(ekipmanlar);
                    break;
                case "2":
                    OduncIslemi(ekipmanlar, ogrenciler);
                    break;
                case "3":
                    IadeIslemi(ekipmanlar);
                    break;
                case "4":
                    MusaitEkipmanlariListele(ekipmanlar);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }

    static void Listele(List<Ekipman> liste)
    {
        foreach (Ekipman ekipman in liste)
        {
            string durum = ekipman.Oduncte
                ? $"Ödünçte ({ekipman.OduncAlanNo})"
                : "Müsait";
            Console.WriteLine($"{ekipman.DemirbasNo} - {ekipman.Ad} - {durum}");
        }
    }

    static void MusaitEkipmanlariListele(List<Ekipman> liste)
    {
        foreach (Ekipman ekipman in liste)
        {
            if (!ekipman.Oduncte)
            {
                Console.WriteLine($"{ekipman.DemirbasNo} - {ekipman.Ad} - Müsait");
            }
        }
    }

    static Ekipman? EkipmanBul(List<Ekipman> liste, string no)
    {
        foreach (Ekipman e in liste)
            if (e.DemirbasNo == no) return e;
        return null;
    }

    static Ogrenci? OgrenciBul(List<Ogrenci> liste, string no)
    {
        foreach (Ogrenci o in liste)
            if (o.Numara == no) return o;
        return null;
    }

    static void OduncIslemi(List<Ekipman> ekipmanlar, List<Ogrenci> ogrenciler)
    {
        Console.Write("Demirbaş no: ");
        string? no = Console.ReadLine();
        if (no == null) return;

        Ekipman? bulunan = EkipmanBul(ekipmanlar, no.Trim().ToUpperInvariant());
        if (bulunan == null)
        {
            Console.WriteLine("Ekipman bulunamadı.");
            return;
        }

        Console.Write("Öğrenci no (1001 veya 1002): ");
        string? ogrenciNo = Console.ReadLine();
        if (ogrenciNo == null) return;

        Ogrenci? ogrenci = OgrenciBul(ogrenciler, ogrenciNo.Trim());
        if (ogrenci == null)
        {
            Console.WriteLine("Öğrenci bulunamadı.");
            return;
        }

        bool sonuc = bulunan.OduncVer(ogrenci.Numara);
        Console.WriteLine(sonuc ? "Ödünç verildi." : "Ekipman zaten ödünçte.");
    }

    static void IadeIslemi(List<Ekipman> ekipmanlar)
    {
        Console.Write("Demirbaş no: ");
        string? no = Console.ReadLine();
        if (no == null) return;

        Ekipman? bulunan = EkipmanBul(ekipmanlar, no.Trim().ToUpperInvariant());
        if (bulunan == null)
        {
            Console.WriteLine("Ekipman bulunamadı.");
            return;
        }

        Console.WriteLine(bulunan.IadeAl()
            ? "İade alındı." : "Ekipman zaten müsait.");
    }
}
