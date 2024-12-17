using BethanysPieShopHRM.HR;
using System.Text;

namespace BethanysPieShopHRM
{
    internal class Utilities
    {
        private static string directory = @"D:\data\BethanysPieShopHRM\";
        private static string fileName = "employees.txt";

        
        private static string GetEmployeeType(Employee employee)
        {
            if (employee is Manager)
                return "2";
            else if (employee is StoreManager)
                return "3";
            else if (employee is JuniorResearcher)
                return "5";
            else if (employee is Researcher)
                return "4";
            else if (employee is Employee)
                return "1";
            return "0";
        }
    }
}
