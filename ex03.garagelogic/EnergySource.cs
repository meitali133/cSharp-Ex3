using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_CurrentEnergyLevel;
        protected readonly float r_MaxEnergyLevel;

        public EnergySource()
        {
        }

        public EnergySource(float i_MaxEnergyLevel)
        {
            r_MaxEnergyLevel = i_MaxEnergyLevel;
        }

        //לשנות את זה שלא יהיה PUBLIC 
        public float CurrentEnergyLevel
        {
            get
            {
                return m_CurrentEnergyLevel;
            }

            set
            {
                m_CurrentEnergyLevel = value;
            }
        }

        public float MaxEnergyLevel
        {
            get
            {
                return r_MaxEnergyLevel;
            }
        }


        /////צריך לבדוק איך זה הולך לילדים בהתאם לסוג המצביע איך צריך להגדיר את הפונקציה
        public virtual abstract void GetEnergySourceDetails(ref StringBuilder o_vehicleDetails);

        
    }
}
