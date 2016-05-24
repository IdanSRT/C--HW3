using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            GarageManager newGarageManager = new GarageManager();
            Console.WriteLine("Hello dear custumer and thanks for coming to our humble garage. \nPlease choose one of the following options:");
            Console.WriteLine("1) Enter a new car for repairing in the garage.");
            Console.WriteLine("2) Show List of car in the Garage.");
            Console.WriteLine("3) Update vehicle status in the garage.");
            Console.WriteLine("4) Fill air in the wheels.");
            Console.WriteLine("5) Fill fuel tank.");
            Console.WriteLine("6) Charge electrical vehicle battery.");
            Console.WriteLine("7) Print vehicle full information.");
            Console.ReadLine();

        }
    }
}
