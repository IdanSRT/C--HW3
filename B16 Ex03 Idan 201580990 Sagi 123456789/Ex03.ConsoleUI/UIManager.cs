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

        public enum eStatus
        {
            InRepair,
            Repaired,
            Piad
        }

        public static void StartService()
        {
            GarageManager newGarageManager = new GarageManager();
            newGarageManager.AddService(new Service(("Enter a new car for repairing in the garage."), eService.AddVehical));
            newGarageManager.AddService(new Service(("Print vehicle List in the Garage."), eService.PrintVehicalList));
            newGarageManager.AddService(new Service(("Update vehicle status in the garage."), eService.UpdateVehicleStatus));
            newGarageManager.AddService(new Service(("Fill air in the Vehicle wheels."), eService.FillAirInWheels));
            newGarageManager.AddService(new Service(("Fuel up vehicle feul tank."), eService.FuelUpTank));
            newGarageManager.AddService(new Service(("Charge up vehicle battery."), eService.ChargeUpBattery));
            newGarageManager.AddService(new Service(("Print vehicle full info and status."), eService.PrintVehicleInfo));
            ServiceOptionChoose(newGarageManager.m_ServiceList);

           
        }


        public static int ServiceOptionChoose(List<Service> i_ServiceList)
        {
            Console.WriteLine("Hello dear custumer and thanks for coming to our humble garage. \nPlease choose one of the following options:");
            for (int service = 1; service < i_ServiceList.Count; service++)
            {
                Console.WriteLine(service + ") " + i_ServiceList[service].ServiceString);
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
