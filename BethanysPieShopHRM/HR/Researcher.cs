using System;
namespace BethanysPieShopHRM.HR
{
    internal class Researcher : Employee
    {

        public Researcher(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate) : base(firstName, lastName, email, birthDay, hourlyRate)
        {
        }

        public int NumberOfPieTastesInvented = 0;
        

        public void ResearchNewPieTastes(int researchHours)
        {
            NumberOfHoursWorked += researchHours;

            if (new Random().Next(100) > 50)//we'll leave it to chance!
            {
                NumberOfPieTastesInvented++;

                Console.WriteLine($"Researcher {FirstName} {LastName} has invented a new pie taste! Total number of pies invented: {NumberOfPieTastesInvented}");
            }
            else
            {
                Console.WriteLine($"Researcher {FirstName} {LastName} is working still on a new pie taste!");
            }
        }
    }
}

