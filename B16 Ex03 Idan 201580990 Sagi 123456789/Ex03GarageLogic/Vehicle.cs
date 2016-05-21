using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eEnergyType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98,
        Electricity
    }

    public class Vehicle
    {
        public string m_ModelName;
        public string m_LisenseNum;
        public float m_EnergyLeft;
        public List<Wheel> m_WheelsList;
        public eEnergyType m_FuleType;
        public float m_MaxEnergy;

        public float MaxEnergy
        {
            get { return m_MaxEnergy; }
            set { m_MaxEnergy = value; }
        }
        


        public Vehicle
            (string i_ModelName, string i_LisenseNum, float i_EnergyLeft, List<Wheel> i_WeelsList, eEnergyType i_FuleType, float i_MaxEnergy)
        {
            m_ModelName = i_ModelName;
            m_LisenseNum = i_LisenseNum;
            m_EnergyLeft = i_EnergyLeft;
            m_WheelsList = i_WeelsList;
            m_FuleType = i_FuleType;
            m_MaxEnergy = i_MaxEnergy;
        }
 
        public float EnergyLeft
        {
            get { return m_EnergyLeft; }
            set { m_EnergyLeft = value; }
        }
        
        public string LisenceNum
        {
            get { return m_LisenseNum; }
            set { m_LisenseNum = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public List<Wheel> WheelsList
        {
            get { return m_WheelsList; }
            set { m_WheelsList = value; }
        }

        public virtual eEnergyType EnergyType
        {
            get { return m_FuleType; }
            set { m_FuleType = value; }
        }

        public abstract bool AddEnergy(eEnergyType i_EnergyType, float i_EnergyAmountToAdd);
        //{
        //    bool wasEnergyAdded = false;
        //    if (this.EnergyType == i_EnergyType)
        //    {
        //        float totalAmount = this.EnergyLeft + i_EnergyAmountToAdd;
        //        if (totalAmount <= this.m_MaxEnergy)
        //        {
        //            this.EnergyLeft += i_EnergyAmountToAdd;
        //            wasEnergyAdded = true;
        //        }
        //    }

        //    return wasEnergyAdded;    
        //}
   
    
    }
}
