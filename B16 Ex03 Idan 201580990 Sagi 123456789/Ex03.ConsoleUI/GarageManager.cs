using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class GarageManager
    {

        private List<VehicleStatusInfo> m_VehiclesList;
        private int m_NumberOfVehicles;
        public List<string> m_ServiceList;

        //constructor
        public void GarageManger(List<string> i_ServiceList)
        {
            m_VehiclesList = new List<VehicleStatusInfo>();
            m_NumberOfVehicles = 0;
            m_ServiceList = i_ServiceList;
        }

        //add service to the options
        public void AddService(string i_ServiceOption)
        {
            m_ServiceList.add(i_ServiceOption);
        }
        
        //(1) to add new vehicle to the garage and to check if he allready inside.
        public void AddVehicle(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhone,GarageLogic.Vehicle i_Vehicle)
        {
            VehicleStatusInfo newVehicle = new VehicleStatusInfo(i_LicenseNumber, i_VehicleOwnerName, i_LicenseNumber, i_Vehicle);
            m_VehiclesList.Add(newVehicle);
            m_NumberOfVehicles++;
        }
        
        //(2)no filter present list of vehicles in the garage
        public void PrintVehicleList()
        {
            Console.WriteLine("List of Vehicles in the garage:");
            for (int index = 0; index < m_VehiclesList.Count; index++)
            {
                Console.WriteLine(m_VehiclesList[index].LicenseNumber + ":" + m_VehiclesList[index].VehicleStatus);
            }
        }

        //(2)no filter present list of vehicles in the garage filtered by status.
        public void PrintFilteredVehicleList(eVehicleStatus i_VehicleStatus)
        {
            Console.WriteLine("List of Vehicles in the garage filtered by the status" + i_VehicleStatus);
            for (int index = 0; index < m_VehiclesList.Count; index++)
            {
                if (m_VehiclesList[index].VehicleStatus == i_VehicleStatus)
                {
                    Console.WriteLine(m_VehiclesList[index].LicenseNumber + ":" + m_VehiclesList[index].VehicleStatus);
                }
            }
        }
        
        //(3)updace the vehicle status by the number license with the new status.
        public void UpdateVehicleStatus(String i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].VehicleStatus = i_VehicleStatus;
        }

        //(4)Fill air in wheels.
        public void FillAir(string i_LicenseNumber)
        {
            m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].Vehicle.GetType();
        }
        
        //check if vehical allready in the garage and return its index on the vehicle status list, if not return -1.
        public int IndexOfVehicle(string i_LicenseNumber)
        {
            int VehicleIndexOnList = -1;
            for (int index = 0; index < m_VehiclesList.Count; index++)
            {
                if (m_VehiclesList[index].LicenseNumber == i_LicenseNumber)
                {
                    VehicleIndexOnList = index;
                }
            }
            return VehicleIndexOnList;
        }

        


        public int ServiceOptionChoose(List<string> i_ServiceList)
        {
            Console.WriteLine("Hello dear custumer and thanks for coming to our humble garage. \nPlease choose one of the following options:");
            for (int service = 1; service < i_ServiceList.Count; service++)
            {
                Console.WriteLine(service + ") " + i_ServiceList[service]);
            }
            Console.WriteLine("1) Enter a new car for repairing in the garage.");
            Console.WriteLine("2) Show List of car in the Garage.");
            Console.WriteLine("3) Update vehicle status in the garage.");
            Console.WriteLine("4) Fill air in the wheels.");
            Console.WriteLine("5) Fill fuel tank.");
            Console.WriteLine("6) Charge electrical vehicle battery.");
            Console.WriteLine("7) Print vehicle full information.");

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
