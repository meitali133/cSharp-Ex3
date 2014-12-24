using System;


namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        public enum eLicensesType
        {
            A = 1,
            A1 = 2,
            AB = 3,
            B2 = 4
        }

        private const int k_NumberOfTires = 2;
        private const float k_MaxAirPressure = 30f;
        private const Fuel.eFuelType k_TypeFuel = Fuel.eFuelType.Octan96;
        private const float k_MaxBatteryTime = 1.8f;
        private const float k_MaxFuelTankCapacity = 6.5f;
        
        private eLicensesType m_LicenseType;
        private int m_EngineCapacityInCc;

        public Motorcycle()
        {

        }
    }
}
