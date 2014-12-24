using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_CurrentEnergyLevel;
        protected readonly float r_MaxEnergyLevel;

        EnergySource(float i_MaxEnergyLevel)
        {
            r_MaxEnergyLevel = i_MaxEnergyLevel;
        }

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


      //  protected abstract void GetEnergyData(out StringBuilder o_EnergyData); על מנת להחזיר את הנתונים על פי סוג דלק/חשמלי

        
    }
}
