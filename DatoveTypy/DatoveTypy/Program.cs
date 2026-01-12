using System;
using System.Collections.Generic;

namespace DatoveTypy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VypocetPrumerneRychlosti(10, 30)); 
            Console.WriteLine(VypocetPrumerneRychlosti(0, 45));  
            Console.WriteLine(VypocetPrumerneRychlosti(5, 0));   
            Console.WriteLine(VypocetPrumerneRychlosti(-5, -1)); 

            Console.WriteLine(PocetSamohlasek("Ahoj světe!"));   
            Console.WriteLine(PocetSamohlasek("ČÁRY MÁRY"));   
            Console.WriteLine(PocetSamohlasek(null));           
            Console.WriteLine(PocetSamohlasek("AbC"));

            var vysledek = ZpracujPole(new int[] { 3, -1, 3, 0, 5 });
            Console.WriteLine(string.Join(", ", vysledek));

            vysledek = ZpracujPole(null);
            Console.WriteLine(string.Join(", ", vysledek));

            vysledek = ZpracujPole(new int[] { -5, -1 });
            Console.WriteLine(string.Join(", ", vysledek));
        }

        static string VypocetPrumerneRychlosti(double vzdalenostKm, double casMin)
        {
            if (vzdalenostKm < 0 || casMin < 0)
                return "Neplatné hodnoty";
            if (casMin == 0)
                return vzdalenostKm > 0 ? "Nelze vypočítat (dělení nulou)" : "Průměrná rychlost: 0,00 km/h";
            double rychlost = vzdalenostKm / (casMin / 60.0);
            return $"Průměrná rychlost: {rychlost:0.00} km/h";
        }

        static int PocetSamohlasek(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            string samohlasky = "aeiouyáéěíóúůý";
            int pocet = 0;
            foreach (char c in text.ToLower())
            {
                if (samohlasky.Contains(c))
                    pocet++;
            }
            return pocet;
        }

        static List<int> ZpracujPole(int[] pole)
        {
            if (pole == null || pole.Length == 0)
                return new List<int>();
            HashSet<int> set = new HashSet<int>();
            foreach (int cislo in pole)
            {
                if (cislo >= 0)
                    set.Add(cislo);
            }
            List<int> vysledek = new List<int>(set);
            for (int i = 0; i < vysledek.Count - 1; i++)
            {
                for (int j = 0; j < vysledek.Count - i - 1; j++)
                {
                    if (vysledek[j] > vysledek[j + 1])
                    {
                        int temp = vysledek[j];
                        vysledek[j] = vysledek[j + 1];
                        vysledek[j + 1] = temp;
                    }
                }
            }
            return vysledek;
        }
    }
}
