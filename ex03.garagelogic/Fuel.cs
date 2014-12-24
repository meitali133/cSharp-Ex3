using System;

namespace Ex03.GarageLogic
{
    public sealed class Fuel : EnergySource
    {
        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4,
        }

        private eFuelType m_FuelType;

        public void Refule(eFuelType i_FuelType, float i_FuelAmountToAdd)
        {
            if (this.m_FuelType != i_FuelType)
            { // if this vehicle uses different fuel type
                throw new ArgumentException("Fuel type for this vehicle is wrong! This Vehicle uses: " + m_FuelType.ToString());
            }

            if(this.m_CurrentEnergyLevel + i_FuelAmountToAdd > this.r_MaxEnergyLevel || i_FuelAmountToAdd < 0 )
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergyLevel - m_CurrentEnergyLevel, "Can't fill the requested fuel - out of limits.");
            }

            this.m_CurrentEnergyLevel += i_FuelAmountToAdd;
        }
    }
}
