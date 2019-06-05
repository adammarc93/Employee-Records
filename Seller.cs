﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Records
{
    class Seller : Worker
    {
        double turnoverValue;
        static readonly double averageMonthlyTurnover = 100000;

        public Seller(string _name, string _lastName, double _workingHoursAmount, double _hourlyRate, double _turnover)
            : base(_name, _lastName, _workingHoursAmount, _hourlyRate)
        {
            turnoverValue = _turnover;
        }

        protected override double CountBonus()
        {
            double bonusPercent = 0.3;

            if (turnoverValue > averageMonthlyTurnover)
            {
                bonusPercent = 0.4;
            }

            return base.CountBasic() * bonusPercent;
        }

        protected override string LastColumnHeading()
        {
            return String.Format(";{0}", "Obrót");
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("{0,10}", turnoverValue);
        }

        public override string TextToFile()
        {
            return base.TextToFile() + String.Format(";{0}", turnoverValue);
        }
    }
}