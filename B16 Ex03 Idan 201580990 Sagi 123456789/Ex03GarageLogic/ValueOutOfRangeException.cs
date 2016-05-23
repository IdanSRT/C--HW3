using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        
        public float MinValue
	{
		get { return MinValue;}
	}
        
        private float m_MaxValue;
        
        public float MaxValue
    {
        get { return m_MaxValue; }
    }

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue){
            // sending two params to the base CTOR:
            : base(string.Format("An error occured while trying to find the word {0} in file {1}", i_MinValue, i_MaxValue,
            i_InnerException));
        }
    }
}
