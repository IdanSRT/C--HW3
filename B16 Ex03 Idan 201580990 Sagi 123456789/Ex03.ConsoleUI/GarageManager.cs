using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageManager
    {

        private List<VehicleStatusInfo> m_VehiclesList;
        private int m_NumberOfVehicles;
        public List<Service> m_ServiceList;

        //constructor
        public void GarageManger(List<Service> i_ServiceList)
        {
            m_VehiclesList = new List<VehicleStatusInfo>();
            m_NumberOfVehicles = 0;
            m_ServiceList = i_ServiceList;
        }

        //add service to the options
        public void AddService(Service i_ServiceOption)
        {
            m_ServiceList.Add(i_ServiceOption);
        }
        
        //(1) to add new vehicle to the garage and to check if he allready inside.
        public void AddVehicle(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhone, Vehicle i_Vehicle)
        {
            VehicleStatusInfo newVehicle = new VehicleStatusInfo(i_LicenseNumber, i_VehicleOwnerName, i_LicenseNumber, i_Vehicle);
            m_VehiclesList.Add(newVehicle);
            m_NumberOfVehicles++;
        }
        
        //(2) Present list of vehicles in the garage
        public void PrintVehicleList()
        {
            Console.WriteLine("List of Vehicles in the garage:");
            foreach (VehicleStatusInfo vehicleStatusInfo in m_VehiclesList)
            {
                Console.WriteLine(vehicleStatusInfo.LicenseNumber + ":" + vehicleStatusInfo.VehicleStatus);
            }
        }

        //(2) Present filtered list of vehicles in the garage status.
        public void PrintFilteredVehicleList(eVehicleStatus i_VehicleStatus)
        {
            Console.WriteLine("List of Vehicles in the garage filtered by the status" + i_VehicleStatus);
            foreach (VehicleStatusInfo vehicleStatusInfo in m_VehiclesList)
            {
                if (vehicleStatusInfo.VehicleStatus == i_VehicleStatus)
                {
                    Console.WriteLine(vehicleStatusInfo.LicenseNumber + ":" + vehicleStatusInfo.VehicleStatus);
                }
            }
        }
        
        //(3)updace the vehicle status by the number license with the new status.
        public void UpdateVehicleStatus(String i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].VehicleStatus = i_VehicleStatus;
        }

        //-------(4)Fill air in wheels.
        public void FillAir(string i_LicenseNumber)
        {
            m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].Vehicle.GetType();
        }
        
        //(5)Fill up Fuel tank for motoric vehicle
        public void FillFuelTank(string i_LicenseNumber)
        {
            Vehicle vehicle = m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].Vehicle;

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
