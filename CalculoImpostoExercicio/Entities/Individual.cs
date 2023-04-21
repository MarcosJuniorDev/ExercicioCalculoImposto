using System.Globalization;

namespace CalculoImpostoExercicio.Entities
{
    internal class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual()
        {
        }

        public Individual(string name, double anualIncome, double healthExpenditures) : base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {
            
            if (AnualIncome < 20000.00)
            {

                return (AnualIncome * 0.15) - (HealthExpenditures / 2.0);
            }
            else
            {
                return (AnualIncome * 0.25) - (HealthExpenditures / 2.0);
            }
            
        }

        public override string ToString()
        {
            return $"{Name}: $ {Tax().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
