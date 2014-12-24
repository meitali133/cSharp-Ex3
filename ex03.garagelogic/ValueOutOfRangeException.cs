using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;
        private string m_Message;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_Message)
        {
            m_Message = i_Message;
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public override string Message
        {
            get
            {
                return m_Message;
            }
        }

    }
}
