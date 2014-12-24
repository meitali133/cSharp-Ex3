using System;

namespace Ex03.GarageLogic
{
    public sealed class Electric : EnergySource
    {
        public void ChargeBattery(float i_AmountHoursToCharge)
        {
            if (this.m_CurrentEnergyLevel + i_AmountHoursToCharge > this.r_MaxEnergyLevel || i_AmountHoursToCharge < 0)
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergyLevel - m_CurrentEnergyLevel, "Can't fill the requested fuel - out of limits.");
            }

            this.m_CurrentEnergyLevel += i_AmountHoursToCharge;
        }
    }
}
