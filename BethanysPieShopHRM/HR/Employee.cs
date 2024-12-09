using System.Net;
using BethanysPieShopHRM.Logic;
using Newtonsoft.Json;

namespace BethanysPieShopHRM.HR
{
    public class Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int NumberOfHoursWorked { get; set; }
        public double Wage { get; set; }
        private double? hourlyRate;

        public DateTime BirthDay { get; set; }
        public Address Address { get; set; }

        private const int minimalHoursWorkedUnit = 1;
        public static double taxRate = 0.15;

        
        
        public double? HourlyRate
        {
            get { return hourlyRate; }
            set
            {
                if (hourlyRate < 0)//this should always be higher than 0
                {
                    hourlyRate = 0;
                }
                else
                {
                    hourlyRate = value;

                }
            }
        }


        public Employee(string firstName, string lastName, string email, DateTime birthDay)
            : this(firstName, lastName, email, birthDay, 0)
        {
        }

        public Employee(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDay = birthDay;
            HourlyRate = hourlyRate ?? 10;

        }

        public Employee(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate, string street, string houseNumber, string zip, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDay = birthDay;
            HourlyRate = hourlyRate ?? 10;

            Address = new Address(street, houseNumber, zip, city);
        }

        public void PerformWork()
        {
            PerformWork(minimalHoursWorkedUnit);
        }

        public void PerformWork(int numberOfHours)
        {
            NumberOfHoursWorked += numberOfHours;
            NumberOfHoursWorked++;

            Console.WriteLine($"{FirstName} {LastName} has worked for {numberOfHours} hour(s)!");
        }

        public int CalculateBonus(int bonus)
        {

            if (NumberOfHoursWorked > 10)
                bonus *= 2;

            Console.WriteLine($"The employee got a bonus of {bonus}");
            return bonus;
        }

        public int CalculateBonusAndBonusTax(int bonus, out int bonusTax)
        {
            bonusTax = 0;
            if (NumberOfHoursWorked > 10)
                bonus *= 2;

            if (bonus >= 200)
            {
                bonusTax = bonus / 10;
                bonus -= bonusTax;
            }

            Console.WriteLine($"The employee got a bonus of {bonus} and the tax on the bonus is {bonusTax}");
            return bonus;
        }

        public virtual void GiveBonus()
        {
            Console.WriteLine($"{FirstName} {LastName} received a generic bonus of 100!");
        }

        public double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
            double taxAmount = wageBeforeTax * taxRate;

            Wage = wageBeforeTax - taxAmount;

            Console.WriteLine($"{FirstName} {LastName} has received a wage of {Wage} for {NumberOfHoursWorked} hour(s) of work.");

            if (resetHours)
                NumberOfHoursWorked = 0;

            return Wage;
        }

        public double CalculateWage()
        {
            WageCalculations wageCalculations = new WageCalculations();

            double calculateValue = wageCalculations.ComplexWageCalculation(Wage, taxRate, 3, 42);

            return calculateValue;

        }

        public string ConvertToJson()
        {
            string json = JsonConvert.SerializeObject(this);

            return json;
        }

        public static void DisplayTaxRate()
        {
            Console.WriteLine($"The current tax rate is {taxRate}");
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nFirst name: \t{FirstName}\nLast name: \t{LastName}\nEmail: \t\t{Email}\nBirthday: \t{BirthDay.ToShortDateString()}\n");
        }

        public void GiveCompliment()
        {
            Console.WriteLine($"You've done a great job, {FirstName}");
        }
    }
}
