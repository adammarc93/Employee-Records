using System;

namespace Employee_Records
{
    class Driver : Worker
    {
        double kilometersAmount;
        static readonly double averageMonthKilometersAmount = 8000;

        public Driver(string _name, string _lastName, double _workingHoursAmount, double _hourlyRate, double _kilometersAmount) :
            base(_name, _lastName, _workingHoursAmount, _hourlyRate)
        {
            kilometersAmount = _kilometersAmount;
        }

        public Driver(string[] tab) : base(tab[0], tab[1], double.Parse(tab[2]), double.Parse(tab[3]))
        {
            kilometersAmount = double.Parse(tab[4]);
        }

        protected override double CountBonus()
        {
            double bonusPercent = 0.1;

            if (kilometersAmount > averageMonthKilometersAmount)
            {
                bonusPercent = 0.2;
            }

            return base.CountBasic() * bonusPercent;
        }

        protected override string LastColumnHeading()
        {
            return String.Format(";{0}", "Kilometers");
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("{0,-10}", kilometersAmount);
        }

        public override string TextToFile()
        {
            return base.TextToFile() + String.Format(";{0}", kilometersAmount);
        }
    }
}