using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        string m_ModelName;
        string m_LisenseNum;
        float m_Energy;
        List<Wheel> m_WheelsList;

   
        public Vehicle(string i_ModelName, string i_LisenseNum, float i_Energy, List<Wheel> i_WeelsList)
        {
            m_ModelName = i_ModelName;
            m_LisenseNum = i_LisenseNum;
            m_Energy = i_Energy;
            m_WheelsList = i_WeelsList;
        }


    }

}
