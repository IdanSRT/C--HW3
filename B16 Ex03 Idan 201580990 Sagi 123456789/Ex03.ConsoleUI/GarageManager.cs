using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private List<VehicleStatusInfo> m_VehiclesList;
        private int m_NumberOfVehicles;
        public List<Service> m_ServiceList;
        
        // Set/get method to the service list field
        public List<Service> ServiceList
        {
            get { return m_ServiceList; }
            set { m_ServiceList = value; }
        }

        // Set/get method to the vehicle list field
        public List<VehicleStatusInfo> VehicleList
        {
            get { return m_VehiclesList; }
            set { m_VehiclesList = value; }
        }

        // Constructor default.
        public GarageManager()
        {
            m_VehiclesList = new List<VehicleStatusInfo>();
            m_NumberOfVehicles = 0;
            m_ServiceList = new List<Service>();
            m_ServiceList.Add(new Service("Enter a new car for repairing in the garage.", eService.AddVehical));
            m_ServiceList.Add(new Service("Print vehicle List in the Garage.", eService.PrintVehicalList));
            m_ServiceList.Add(new Service("Update vehicle status in the garage.", eService.UpdateVehicleStatus));
            m_ServiceList.Add(new Service("Fill air in the Vehicle wheels.", eService.FillAirInWheels));
            m_ServiceList.Add(new Service("Fuel up vehicle feul tank.", eService.FuelUpTank));
            m_ServiceList.Add(new Service("Charge up vehicle battery.", eService.ChargeUpBattery));
            m_ServiceList.Add(new Service("Print vehicle full info and status.", eService.PrintVehicleInfo));
        }
        
        // Constuctor with custome services
        public  GarageManager(List<Service> i_ServiceList)
        {
            m_VehiclesList = new List<VehicleStatusInfo>();
            m_NumberOfVehicles = 0;
            m_ServiceList = i_ServiceList;
        }

        // (1) To add new vehicle to the garage and to check if he allready inside.
        public void AddVehicle(string i_LicenseNumber, string i_VehicleOwnerName, string i_VehicleOwnerPhone, Vehicle i_Vehicle)
        {
                VehicleStatusInfo newVehicle = new VehicleStatusInfo(i_LicenseNumber, i_VehicleOwnerName, i_LicenseNumber, i_Vehicle);
                m_VehiclesList.Add(newVehicle);
                m_NumberOfVehicles++;
        }
        
        // (2) Present list of vehicles in the garage
        public void PrintVehicleList()
        {
            Console.WriteLine("List of Vehicles in the garage:");
            foreach (VehicleStatusInfo vehicleStatusInfo in m_VehiclesList)
            {
                Console.WriteLine(vehicleStatusInfo.LicenseNumber + ":" + vehicleStatusInfo.VehicleStatus);
            }
        }

        // (2) Present filtered list of vehicles in the garage status.
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
        
        // (3) updace the vehicle status by the number license with the new status.
        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].VehicleStatus = i_VehicleStatus;
        }

        // (4) Fill air in wheels.
        public void FillAir(string i_LicenseNumber)
        {
            List<Wheel> vehicleWheelsList = m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].Vehicle.WheelsList;
            foreach (Wheel currWheel in vehicleWheelsList)
            {
                // Calculate the amount of air to fill
                float currWheelAirPressureToAdd = currWheel.MaxPossiblePressure - currWheel.AirPressure;
                currWheel.AddAir(currWheelAirPressureToAdd);
            }
        }

        // (5)+(6) Fill up Fuel tank for motoric vehicle and charge battery.
        public void AddEnergy(string i_LicenseNumber)
        {
            Vehicle currVehicle = m_VehiclesList[IndexOfVehicle(i_LicenseNumber)].Vehicle;
            eEnergyType vehicleEnergyType = currVehicle.m_EngineEnergyType;
            float vehicleEnergyToAdd = currVehicle.EnergyLeft - currVehicle.MaxEnergy;
            currVehicle.AddEnergy(vehicleEnergyType, vehicleEnergyToAdd);
        }

        //--(7)  Print vehicle information and status
        public void PrintVehicleInfo(string i_LicenseNumber)
        {
            VehicleStatusInfo vehicleStatusInfo = m_VehiclesList[IndexOfVehicle(i_LicenseNumber)];
            //WriteLine<Vehicle>(vehicleStatusInfo.Vehicle);
            //Console.WriteLine("Information and status:");
            //Console.WriteLine("Vehicle license NO." + i_LicenseNumber);
            //Console.WriteLine("Vehicle model :" + vehicleStatusInfo.Vehicle.m_ModelName);
            //Console.WriteLine("Vehicle owner name :" + vehicleStatusInfo.VehicleOwnerName);
            //Console.WriteLine("Vehicle status in the Garage :" + vehicleStatusInfo.VehicleStatus);
            //Console.WriteLine("Vehicle wheels air pressure :" + vehicleStatusInfo.Vehicle.WheelsList[1].AirPressure);
            //Console.WriteLine("Vehicle wheels manufacturer :" + vehicleStatusInfo.Vehicle.WheelsList[1].Manufacture);
            //Console.WriteLine("Vehicle energy type :" + vehicleStatusInfo.Vehicle.m_EngineEnergyType);
            //Console.WriteLine("Vehicle energy Status :" + vehicleStatusInfo.Vehicle.m_EnergyLeft);
        }

        // Check if vehical allready in the garage and return its index on the vehicle status list, if not return -1.
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
        
        //Helper for printing
        //public static void WriteLine<T>(T obj)
        //{
        //    var t = typeof(T);
        //    var props = t.GetProperties();
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in props)
        //    {
        //        sb.Append($"{item.Name}:{item.GetValue(obj, null)}; ");
        //    }
        //    sb.AppendLine();
        //    Console.WriteLine(sb.ToString());
        //}
        
    }
}
