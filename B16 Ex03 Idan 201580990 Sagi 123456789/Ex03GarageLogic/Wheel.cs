using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        string m_Manufacture;
        float m_AirPressure;
        float m_MaxPssiblePressure;

        public Wheel(string i_Manufacture, float i_AirPressure, float i_MaxPossiblePressure)
        {
            this.m_Manufacture = i_Manufacture;
            m_AirPressure = i_AirPressure;
            m_MaxPssiblePressure = i_MaxPossiblePressure;
        }

        public string Manufacture
        {
            get { return m_Manufacture;}
            set { m_Manufacture = value; }
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }

        public float MaPossiblePressure
        {
            get { return m_MaxPssiblePressure; }
            set { m_MaxPssiblePressure = value; }
        }

        public bool AddAir(float airPressureToAdd)
        {
            bool isPossibleToAdd = false;
            float newAirPressure = this.AirPressure + airPressureToAdd;
            if (newAirPressure <= this.m_MaxPssiblePressure)
            {
                this.AirPressure = this.AirPressure + airPressureToAdd;
                isPossibleToAdd = true;
            }
            return isPossibleToAdd;
        }
    }
}
