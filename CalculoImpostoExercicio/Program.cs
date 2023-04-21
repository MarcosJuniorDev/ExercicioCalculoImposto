using CalculoImpostoExercicio.Entities;
using System.Globalization;

namespace CalculoImpostoExercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);                
                if (ch == 'i')
                {                    
                    Console.Write("Health expenditure: ");
                    double healthExpenditure = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(name, anualIncome, healthExpenditure));
                }
                else
                {                    
                    Console.Write("Number of employees: ");
                    int nEmployee = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(name, anualIncome, nEmployee));
                }
            }

            Console.WriteLine();
            double sum = 0.0;
            Console.WriteLine("TAXES PAID: ");
            foreach (TaxPayer taxPayer in taxPayers)
            {
                Console.WriteLine(taxPayer);
                sum += taxPayer.Tax();                
            }
            Console.WriteLine($"TOTAL TAXES: {sum.ToString("F2", CultureInfo.InvariantCulture)}");
           
        }
    }
}