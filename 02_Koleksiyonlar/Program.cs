using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] sabitNumaralar = { "LAB-001", "LAB-002", "LAB-003" };
        for (int i = 0; i < sabitNumaralar.Length; i++)
            Console.WriteLine(sabitNumaralar[i]);

        var numaralar = new List<string> { "LAB-001", "LAB-002" };
        numaralar.Add("LAB-003");
        numaralar.Remove("LAB-002");
        Console.WriteLine($"List eleman sayısı: {numaralar.Count}");

        foreach (string no in numaralar)
            Console.WriteLine(no);

        Console.WriteLine($"İlk eleman: {NumaraVarMi(numaralar, "LAB-001")}");
        Console.WriteLine($"Son eleman: {NumaraVarMi(numaralar, "LAB-003")}");
        Console.WriteLine($"Olmayan: {NumaraVarMi(numaralar, "LAB-999")}");
        Console.WriteLine($"Boş liste: {NumaraVarMi(new List<string>(), "LAB-001")}");
    }

    static bool NumaraVarMi(List<string> liste, string aranan)
    {
        foreach (string numara in liste)
        {
            if (numara == aranan)
                return true;
        }
        return false;
    }
}
