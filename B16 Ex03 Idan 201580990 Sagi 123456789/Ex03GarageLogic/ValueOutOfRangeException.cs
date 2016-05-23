using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        
        public float MinValue
	{
		get { return MinValue;}
	}

        private string m_Message;

        public string Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }
        
        
        private float m_MaxValue;
        
        public float MaxValue
    {
        get { return m_MaxValue; }
    }

        // Constructor with an attributed message
        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue, string i_ToFormatMessage) :
            base(string.Format(i_ToFormatMessage, i_MinValue, i_MaxValue), i_InnerException)
        { }

        // Constructor with an uppriorry message
        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base(string.Format("An error occured while trying enter a value that is not in the range of {0} and {1}", i_MinValue, i_MaxValue),
            i_InnerException)
        { }
    }
}
