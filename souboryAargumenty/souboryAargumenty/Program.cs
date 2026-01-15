using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var predmety = new Dictionary<string, List<int>>
        {
            { "Matematika", new List<int> { 1, 2, 1, 3, 2 } },
            { "Fyzika", new List<int> { 2, 3, 2, 1, 3 } },
            { "Elektrotechnika", new List<int> { 3, 3, 2, 2 } },
            { "Programování", new List<int> { 1, 1, 2, 1, 2 } },
            { "Sítě", new List<int> { 2, 3, 2, 3, 3 } },
            { "Angličtina", new List<int> { 1, 2, 1, 1, 2 } },
            { "Automatizace", new List<int> { 1, 2, 2, 3, 1, 2, 1 } }
        };

        double celkovySoucet = 0;
        int pocetZnamek = 0;

        Console.WriteLine("Průměry předmětů:\n");

        foreach (var predmet in predmety)
        {
            double prumer = predmet.Value.Average();
            Console.WriteLine($"{predmet.Key}: {prumer:F2}");

            celkovySoucet += predmet.Value.Sum();
            pocetZnamek += predmet.Value.Count;
        }

        double celkovyPrumer = celkovySoucet / pocetZnamek;

        Console.WriteLine("\nCelkový průměr: " + celkovyPrumer.ToString("F2"));
        Console.ReadLine();
    }
}

