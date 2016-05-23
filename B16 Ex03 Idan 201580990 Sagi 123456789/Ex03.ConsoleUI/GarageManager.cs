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

        public void GarageManger()
        {
            m_VehiclesList = new List<VehicleStatusInfo>();
            m_NumberOfVehicles = 0;
        } 
        //(1) to add new vehicle to the garage and to check if he allready inside.
        public void AddVehicle(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhone)
        {
            VehicleStatusInfo NewVehicle = new VehicleStatusInfo(i_LicenseNumber, i_VehicleOwnerName, i_LicenseNumber);
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
    }
}
