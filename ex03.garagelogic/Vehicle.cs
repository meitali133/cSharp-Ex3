using System;
using System.Collections.Generic;
using System.Text;

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

        internal virtual void GetVehicleDetails(ref StringBuilder o_VehicleDetails)
        {
            int tireIndex = 1;

            o_VehicleDetails.AppendFormat(
                "{0}License plate number: {1}.{0}Model Name: {2}.{0}Energy Level: {3}%{0}",
                Environment.NewLine,
                m_LicensePlate,
                m_ModelName,
                string.Format("{0:0.00}", m_EnergyPrecentLeft));

            ///////צריך איכשהו שהמתודה האבסטרקטית תעבוד..... לא יודעת עוד איך 
            m_EnergySource.GetEnergySourceDetails(ref o_VehicleDetails);
            foreach (Tire tire in m_TireCollection)
            {
                o_VehicleDetails.AppendFormat("{0}Tire {1} data:", Environment.NewLine, tireIndex);
                tire.GetTireDetails(ref o_VehicleDetails);
                tireIndex++;
            }
        }
    }
}
