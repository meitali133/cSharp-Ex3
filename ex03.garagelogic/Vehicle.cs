using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        private float m_EnergyPrecentLeft;
        private List<Tire> m_TireCollection;
        private EnergySource m_EnergySource;

        internal List<Tire> TireCollection
        {
            get
            {
                return m_TireCollection;
            }

            set 
            {
                m_TireCollection = value;
            }
        }

        public string ModulName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }

            set
            {
                m_LicensePlate = value;
            }
        }

        public float EnergyPrecentLeft
        {
            get
            {
                return m_EnergyPrecentLeft;
            }

            set
            {
                m_EnergyPrecentLeft = value; 
            }
        }

        public EnergySource EnergySourceVehicle
        {
            get
            {
                return m_EnergySource;
            }

            set
            {
                m_EnergySource = value;
            }
        }

        public void AddMaxAirPressureToTheTires()
        {
            foreach (Tire tireToFillAirPressure in m_TireCollection)
            {
                tireToFillAirPressure.AddMaxAirPressure();
            }
        }

        internal void CalculateAndSetEnergyPercentLeft()
        {
            m_EnergyPrecentLeft = (m_EnergySource.CurrentEnergyLevel * 100) / m_EnergySource.MaxEnergyLevel;
        }
    }
}
