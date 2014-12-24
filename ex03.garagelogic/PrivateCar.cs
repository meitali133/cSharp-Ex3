using System;


namespace Ex03.GarageLogic
{
    class PrivateCar : Vehicle
    {
        public enum eCarColor
        {
            White = 1,
            Green = 2,
            Blue = 3,
            Red = 4
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
        
        private const int k_NumberOfTires = 4;
        private const float k_MaxAirPressure = 29f;
        private const Fuel.eFuelType k_TypeFuel = Fuel.eFuelType.Octan95;
        private const float k_MaxBatteryTime = 2.6f;
        private const float k_MaxFuelTankCapacity = 45f;

        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
    }
}
