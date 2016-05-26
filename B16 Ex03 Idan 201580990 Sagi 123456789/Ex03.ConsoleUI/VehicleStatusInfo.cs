using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public enum eVehicleStatus
    {
        InRepair,
        Repaired,
        Piad
    }

    public class VehicleStatusInfo
    {
        
        private String m_LicenseNumber;
        private String m_VehicleOwnerName;
        private String m_VehicleOwnerPhone;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;
        private eVehicleType m_VehicleType;

        public eVehicleType vehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }


        public Vehicle Vehicle
        {
            get { return Vehicle; }
            set { Vehicle = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public String LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public VehicleStatusInfo(String i_VehicleLicenseNumber,String i_VehicleOwnerName, String i_VehicleOwnerPhone, Vehicle i_Vehicle)
        {
            m_LicenseNumber = i_VehicleLicenseNumber;
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
    }

        public VehicleStatusInfo(String i_VehicleLicenseNumber, String i_VehicleOwnerName, String i_VehicleOwnerPhone, Truck i_Vehicle)
        {
            m_LicenseNumber = i_VehicleLicenseNumber;
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
        }

        public VehicleStatusInfo(String i_VehicleLicenseNumber, String i_VehicleOwnerName, String i_VehicleOwnerPhone, Car i_Vehicle)
        {
            m_LicenseNumber = i_VehicleLicenseNumber;
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
        }

        public VehicleStatusInfo(String i_VehicleLicenseNumber, String i_VehicleOwnerName, String i_VehicleOwnerPhone, Motorcycle i_Vehicle)
        {
            m_LicenseNumber = i_VehicleLicenseNumber;
            m_VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_Vehicle = i_Vehicle;
        }
        public String VehicleOwnerName
        {
            get { return m_VehicleOwnerName; }
            set { m_VehicleOwnerName = value; }
        }

        public String VehicleOwnerPhone
        {
            get { return m_VehicleOwnerPhone; }
            set { m_VehicleOwnerPhone = value; }
        }
    }
}
