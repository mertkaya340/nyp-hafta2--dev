using System;

class Program
{
    static void Main()
    {
        string demirbasNo = "LAB-001";
        bool oduncte = false;
        decimal bedel = 1250.50m;
        var adet = 2;
        const int AzamiGun = 7;
        Console.WriteLine($"{demirbasNo}, bedel: {bedel}, adet: {adet}");
        Console.WriteLine($"7 / 2 = {7 / 2}; ondalıklı: {(double)7 / 2}");

        Console.Write("Kaç gün? ");
        string? giris = Console.ReadLine();
        if (!int.TryParse(giris, out int gun) || gun < 1 || gun > AzamiGun)
        {
            Console.WriteLine("1-7 arası sayı girin.");
            return;
        }

        bool sonuc = OduncUygunMu(oduncte, gun);
        Console.WriteLine(sonuc ? "Ödünç verilebilir." : "Talep uygun değil.");

        int once = gun;
        Arttir(gun);
        Console.WriteLine($"Arttir çağrısından sonra gun: {gun}; önce: {once}");

        for (int i = 0; i < 3; i++)
            Console.WriteLine($"Tur: {i}");
    }

    static bool OduncUygunMu(bool oduncte, int gun)
    {
        return !oduncte && gun >= 1 && gun <= 7;
    }

    static void Arttir(int gun)
    {
        gun++;
    }
}
