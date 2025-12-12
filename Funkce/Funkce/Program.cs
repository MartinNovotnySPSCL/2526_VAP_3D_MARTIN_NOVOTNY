void print(params string[] messages)
{
    foreach (string message in messages)
    {
        Console.WriteLine(message);
    }
}

(int, int) getMinMax(params int[] numbers)
{
    if (numbers.Length == 0) return (0, 0);
    int min = numbers[0];
    int max = numbers[0];
    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] < min) min = numbers[i];
        if (numbers[i] > max) max = numbers[i];
    }
    return (min, max);
}

string input(string prompt)
{
    Console.WriteLine(prompt);
    return Console.ReadLine() ?? "";
}

double ObsahTrojuhelniku(double zakladna, double vyska)
{
    return 0.5 * zakladna * vyska;
}

string FormatujCislo(double cislo)
{
    string text = cislo.ToString();
    string[] casti = text.Split(',');
    string celaCast = casti[0];
    string desetinnaCast = "";
    if (casti.Length > 1)
    {
        desetinnaCast = casti[1];
        string vysledek = "";
        for(int i = celaCast.Length - 1; i >= 0; i--)
        {
            vysledek += celaCast[i];
            if ((celaCast.Length - i) % 3 == 0)
                vysledek = " " + vysledek;
        }

        return vysledek + "," + desetinnaCast;
    }
}

string name = input("Zadejte název souboru");
(int min, int max) = getMinMax(1, 2, 3, 4, 5, 6, 7);
print(name, min.ToString(), max.ToString());
print(ObsahTrojuhelniku(5, 7).ToString());
print(FormatujCislo(1001));
