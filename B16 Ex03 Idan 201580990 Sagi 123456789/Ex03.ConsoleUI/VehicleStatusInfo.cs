using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private String m_CarOwnerName;
        private String m_CarOwnerPhone;
        private eVehicleStatus m_VehicleStatus;

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


        public VehicleStatusInfo(String i_CarLicenseNumber,String i_CarOwnerName, String i_CarOwnerPhone)
        {
            m_LicenseNumber = i_CarLicenseNumber;
            m_CarOwnerName = i_CarOwnerName;
            m_CarOwnerPhone = i_CarOwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
    }

        public String CarOwnerName
        {
            get { return m_CarOwnerName; }
            set { m_CarOwnerName = value; }
        }

        public String CarOwnerPhone
        {
            get { return m_CarOwnerPhone; }
            set { m_CarOwnerPhone = value; }
        }
    }
}
