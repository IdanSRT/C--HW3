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
            Console.WriteLine("\nHello Customer, welcome to our humble garage. \nPlease choose one of the following options:");
            UIManager newUIManager = new UIManager();
            newUIManager.StartService();


            Console.ReadLine();
        }

    }
}
