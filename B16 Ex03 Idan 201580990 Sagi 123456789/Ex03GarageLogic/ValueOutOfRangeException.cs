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
        private float m_MaxValue;
        private string m_Message;

       
        // Constractor
        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue, string i_Message)
            : base(string.Format(i_Message, i_MinValue, i_MaxValue), i_InnerException)
        {
            m_Message = i_Message;
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;

        }

        // Default m_Message Constructor
        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base(string.Format("An error occured while trying enter a value that is not in the range of {0} and {1}", i_MinValue, i_MaxValue),
            i_InnerException)
        { }

        // Message get / set
        public override string Message
        {
            get { return m_Message; }
        }

        // MinValue get / set
        public float MinValue
        {
            get { return MinValue; }
        }

        // MaxValue get / set
        public float MaxValue
        {
            get { return m_MaxValue; }
        }
    }
}
