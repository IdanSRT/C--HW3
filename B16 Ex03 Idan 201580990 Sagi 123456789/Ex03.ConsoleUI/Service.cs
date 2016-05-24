using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class Service
    {

        private string m_ServiceString;
        private Enum m_eService;

        public enum eService
        {
            AddVehical,
            PrintVehicalList,
            UpdateVehicleStatus,
            FillAirInWheels,
            FuelUpTank,
            ChargeUpBattery,
            PrintVehicleInfo
        }

        public void Service(string i_ServiceOffered, Enum i_Service)
        {
            m_ServiceString = i_ServiceOffered;
            m_eService = i_Service;
        }

        public string ServiceString
        {
            get { return m_ServiceString; }
            set { m_ServiceString = value; }
        }

        public Enum enumService
        {
            get { return m_eService; }
            set { m_eService = value; }
        }

        

    }
}
