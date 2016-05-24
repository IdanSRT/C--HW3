using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class UIManager
    {
        private GarageManager m_GarageManager;

        public enum eService
        {
            ,
            Repaired,
            Piad
        }

        public static void StartService()
        {
            GarageManager newGarageManager = new GarageManager();
            newGarageManager.AddService(new BuildService(("Enter a new car for repairing in the garage."), Service.eService.AddVehical);
            newGarageManager.AddService("Show List of car in the Garage.");
            newGarageManager.AddService("Update vehicle status in the garage.");
            newGarageManager.AddService("Fill air in wheels.");
            newGarageManager.AddService("Fuel up vehicle feul tank.");
            newGarageManager.AddService("Charge vehicle battaery.");
            newGarageManager.AddService("Print vehicle full info and status.");
            ServiceOptionChoose(newGarageManager.m_ServiceList);


        }


        public static int ServiceOptionChoose(List<Service> i_ServiceList)
        {
            Console.WriteLine("Hello dear custumer and thanks for coming to our humble garage. \nPlease choose one of the following options:");
            for (int service = 1; service < i_ServiceList.Count; service++)
            {
                Console.WriteLine(service + ") " + i_ServiceList[service]);
            }

            string inputNumStr = Console.ReadLine();
            int inputServiceNumInt;
            bool goodInput = int.TryParse(inputNumStr, out inputServiceNumInt);
            while (!goodInput || inputServiceNumInt < 1 || inputServiceNumInt > i_ServiceList.Count)
            {
                Console.WriteLine("Input is not valid. \nPlease choose a service number between the range " + 0 + " to " + i_ServiceList.Count + ":");
                inputNumStr = Console.ReadLine();
                goodInput = int.TryParse(inputNumStr, out inputServiceNumInt);
            }
            return inputServiceNumInt;
        }
    }
}
