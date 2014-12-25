using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 3
        }

        private readonly Vehicle r_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleStatus m_VehicleStatus;

        public VehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            this.r_Vehicle = i_Vehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public string Name
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_OwnerPhone;
            }

            set
            {
                m_OwnerPhone = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        internal void AddMaxAirPressure()
        {
            r_Vehicle.AddMaxAirPressureToTheTires();
        }

        internal void RefuelVehicleTank(Fuel.eFuelType i_FuelType, float i_AmmountOfFuelToAdd)
        {
            if (r_Vehicle.EnergySourceVehicle is Fuel)
            {
                Fuel fuelEnergySource = (Fuel)r_Vehicle.EnergySourceVehicle;
                fuelEnergySource.Refule(i_FuelType, i_AmmountOfFuelToAdd);
            }
            else
            {
                throw new ArgumentException("This vehicle is not driven by fuel. this is electric vehicle!");
            }

            r_Vehicle.CalculateAndSetEnergyPercentLeft();
        }

        internal void ChargeBattery(float i_HoursToAdd)
        {
            if (r_Vehicle.EnergySourceVehicle is Electric)
            {
                Electric fuelEnergySource = (Electric)r_Vehicle.EnergySourceVehicle;
                fuelEnergySource.ChargeBattery(i_HoursToAdd);
            }
            else
            {
                throw new ArgumentException("This is not electric vehicle. this vehicle driven by fuel!");
            }

            r_Vehicle.CalculateAndSetEnergyPercentLeft();
        }

        internal void ChangeStatus(eVehicleStatus i_NewVehicleStatus)
        {
            m_VehicleStatus = i_NewVehicleStatus;
        }

        internal void GetVehicleDetails(ref StringBuilder o_VehicleDetails)
        {
            o_VehicleDetails.AppendFormat("License Plate: {3} , Owner name: {0} ,Phone number: {1} , Vehicle status: {2}",
                Name,PhoneNumber,VehicleStatus.ToString(), r_Vehicle.LicensePlate);
            r_Vehicle.GetVehicleDetails(ref o_VehicleDetails);
          
        }

    }
}
