using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Records
{
    public abstract class Worker : IComparable<Worker>
    {
        public string name;
        public string lastName;
        double workingHoursAmount;
        double hourlyRate;

        public Worker(string _name, string _lastName, double _workingHoursAmount, double _hourlyRate)
        {
            name = _name;
            lastName = _lastName;
            workingHoursAmount = _workingHoursAmount;
            hourlyRate = _hourlyRate;
        }

        protected virtual double CountBasic()
        {
            return workingHoursAmount * hourlyRate;
        }

        public int CompareTo(Worker other)
        {
            int result = lastName.CompareTo(other.lastName);
            if (result == 0)
            {
                result = name.CompareTo(other.name);
            }

            return result;
        }

        protected abstract double CountBonus();

        protected abstract string LastColumnHeading();

        public override string ToString()
        {
            return String.Format("{0,-10}{1,-10}{2,8:F2}{3,8:F2}{4,12:F2}{5,8:F2}",
                name, lastName, workingHoursAmount, hourlyRate, CountBasic(), CountBonus());
        }

        public virtual string TextToFile()
        {
            return String.Format("{0};{1};{2};{3};{4};{5}",
                name, lastName, workingHoursAmount, hourlyRate, CountBasic(), CountBonus());
        }
    }
}