using System;
using System.Data;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Zadejte matematický výraz (nebo napište 'konec' pro ukončení):");
            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "konec")
                break;
            try
            {
                var result = new DataTable().Compute(input, null);
                Console.WriteLine($"Výsledek: {result}");
            }
            catch (Exception)
            {
                Console.WriteLine("Chybný výraz. Zkuste to znovu.");
            }
        }
    }
}
