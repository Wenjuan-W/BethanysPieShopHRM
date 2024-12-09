using System;
namespace BethanysPieShopHRM.HR
{
    internal class Developer : Employee
    {
        public string CurrentProject;

        public Developer(string firstName, string lastName, string email, DateTime birthDay, double? hourlyRate) : base(firstName, lastName, email, birthDay, hourlyRate)
        {
        }
    }
}

