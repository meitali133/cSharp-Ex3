using System;

namespace Ex03.GarageLogic
{
    class Tire
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        /*
         *  פונקציה או משתנה המוגדרים אינטרנל ניתנים לגישה לכל 
         *  פונקציה או מחלקה הנמצאת איתם באותו ה-ניימספייס.
         *  הרשאה זו הינה הרשאת ברירת המחדל במידה ואיננו מציינים את ההרשאה הרצויה לנו, 
         *  אך מומלץ ביותר להגדיר תמיד את ההרשאה בה אנו מעוניינים.
          */
        internal Tire(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.m_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufecturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        //setter לא צריך להיות פאבליק צריך להיות בפונקציה משלו כנראה
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        internal void AddMaxAirPressure()
        {
            AddAirPressureToTire(r_MaxAirPressure - m_CurrentAirPressure);
        }

        internal void AddAirPressureToTire(float i_AmountOfAirPressureToAdd)
        {
            if (this.m_CurrentAirPressure + i_AmountOfAirPressureToAdd > this.r_MaxAirPressure || i_AmountOfAirPressureToAdd < 0)
            {
                throw new ValueOutOfRangeException(0, r_MaxAirPressure - m_CurrentAirPressure, "Can't fill the requested air pressure - out of limits.");
            }
            else
            {
                this.m_CurrentAirPressure += i_AmountOfAirPressureToAdd;
            }
        }

    }
}
