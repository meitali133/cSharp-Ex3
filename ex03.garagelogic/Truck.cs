using System;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {

        private const int k_NumberOfTires = 8;
        private const float k_MaxAirPressure = 24f;
        private const Fuel.eFuelType k_TypeFuel = Fuel.eFuelType.Soler;
        private const float k_MaxFuelTankCapacity = 200f;

        private float r_MaxCarryingWeight;
        private bool m_IsCarringHazardousMaterials;
        private float m_CurrentCarringWeight;

    }
}
