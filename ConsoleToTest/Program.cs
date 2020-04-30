using SupermarketManagement.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StaffRepository staffRepository = new StaffRepository();
            var test = staffRepository.GetAll().ToList();
            if (test == null)
            {
                Console.WriteLine("not found");
            }
            else
            {
                Console.WriteLine($"found {test.Count} staff!");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
