using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class EnergyDoesNotMatchToEngine : Exception
    {
        private eEnergyType m_EnergyTypeToAdd;
        private eEnergyType m_EngineEnergyType;

        public EnergyDoesNotMatchToEngine(Exception i_InnerException, eEnergyType i_EnergyTypeToAdd, eEnergyType i_EngineEnergyType)
            : base(string.Format("An error occured while trying to add energy type {0} to a car engine type {1}", i_EnergyTypeToAdd, i_EngineEnergyType),
            i_InnerException)
        {
            m_EnergyTypeToAdd = i_EnergyTypeToAdd;
            m_EngineEnergyType = i_EngineEnergyType;
        }


        public eEnergyType EnergyType
        {
            get { return m_EnergyTypeToAdd; }
        }
        public eEnergyType EngineEnergyType
        {
            get { return m_EngineEnergyType; }
        }





    }
}
