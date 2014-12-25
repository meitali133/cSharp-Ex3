using System;
using System.Text;

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

        public override abstract void GetEnergySourceDetails(ref StringBuilder o_vehicleDetails)
        {
            Electric electricEngine = (Electric)this;
            o_vehicleDetails.AppendFormat(
                "{0}The current battery level is: {1} hours. {0}Max battery time is: {2} hours{0}",
                Environment.NewLine,
                electricEngine.CurrentEnergyLevel,
                electricEngine.MaxEnergyLevel);
        }
    }
}
