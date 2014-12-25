using System;
using System.Collections.Generic;
using System.Text;


namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_LicensePlateAndVehicle;

        public Garage()
        {
            m_LicensePlateAndVehicle = new Dictionary<string, VehicleInGarage>();
        }

        public void AddVehicleToTheGarage(VehicleInGarage i_VehicleToAdd)
        {
            m_LicensePlateAndVehicle.Add(i_VehicleToAdd.Vehicle.LicensePlate, i_VehicleToAdd);
        }

        public VehicleInGarage FindVehicleByLicensePlate(string i_LicensePlate)
        {
            VehicleInGarage currentVehicle = null;
            bool isVehicleExists = m_LicensePlateAndVehicle.TryGetValue(i_LicensePlate, out currentVehicle);

            if (isVehicleExists == false)
            {
                throw new ArgumentException("This License Plate is WRONG! This license plate doesn't exists in the garage.");
            }

            return currentVehicle;
        }


        /// <summary>
        /// This method check if the car exists in the garage,
        /// if the car exists change the status of the vehicle to "inRepair" mode
        /// 
        /// </summary>
        /// <param name="i_LicensePlate"></param>
        /// <returns>true if the car exists, false if the car is not exists in the garage</returns>
        public bool CheckIfVehicleInTheGarageAndChangeTheVehicleStatusToRepair(string i_LicensePlate)
        {
            VehicleInGarage vehicleInGarage;
            bool isCarExist = false;

            isCarExist = m_LicensePlateAndVehicle.TryGetValue(i_LicensePlate, out vehicleInGarage);
            if (isCarExist == true)
            {
                vehicleInGarage.VehicleStatus = VehicleInGarage.eVehicleStatus.InRepair;
            }

            return isCarExist;
        }

        //סעיף 2
        public List<string> getLicensePlateOfAllTheVehiclesInTheGarage()
        {
            List<string> allVehiclesLicensePlate = getVehiclesLicensePlateByStatus(VehicleInGarage.eVehicleStatus.InRepair);
            allVehiclesLicensePlate.AddRange(getVehiclesLicensePlateByStatus(VehicleInGarage.eVehicleStatus.Repaired));
            allVehiclesLicensePlate.AddRange(getVehiclesLicensePlateByStatus(VehicleInGarage.eVehicleStatus.Paid));

            return allVehiclesLicensePlate;
        }
        //המשך סעיף 2
        public List<string> getVehiclesLicensePlateByStatus(VehicleInGarage.eVehicleStatus i_FilterByStatus)
        {
            List<string> licensePlates = new List<string>();

            foreach (KeyValuePair<string, VehicleInGarage> currentVehicle in m_LicensePlateAndVehicle)
            {
                if (currentVehicle.Value.VehicleStatus == i_FilterByStatus)
                {
                    licensePlates.Add(currentVehicle.Key);
                }
            }

            return licensePlates;
        }

        //סעיף 3
        //הפונקציה הזאת זורקת שגיאה במקרה שלא מצאה לוחית רישוי תואמת יש לטפל בUI
        public void ChangeVehicleStatusInGarage(string i_LicensePlate, VehicleInGarage.eVehicleStatus i_NewVehicleStatus)
        {
            VehicleInGarage vehicleToChangeStatus = FindVehicleByLicensePlate(i_LicensePlate);
            vehicleToChangeStatus.ChangeStatus(i_NewVehicleStatus);
        }
        //סעיף 4
        //הפונקציה הזאת זורקת שגיאה במקרה שלא מצאה לוחית רישוי תואמת יש לטפל בUI
        public void AddMaxAirPressureToVehicle(string i_LicensePlate)
        {
            VehicleInGarage vehicleToAddMaxAirPressure = FindVehicleByLicensePlate(i_LicensePlate);
            vehicleToAddMaxAirPressure.AddMaxAirPressure();
        }

        //סעיף 5
        //הפונקציה הזאת זורקת שגיאה במקרה שלא מצאה לוחית רישוי תואמת יש לטפל בUI
        //RefuelVehicleTank זורקת אקספשן במידה והרכב לא מונע על ידי דלק
        public void RefuleVehicle(string i_LicensePlate, Fuel.eFuelType i_FuelType, float i_AmmountOfFuelToAdd)
        {
            VehicleInGarage vehicleToFill = FindVehicleByLicensePlate(i_LicensePlate);
            vehicleToFill.RefuelVehicleTank(i_FuelType, i_AmmountOfFuelToAdd);
        }

        //סעיף 6
        //הפונקציה הזאת זורקת שגיאה במקרה שלא מצאה לוחית רישוי תואמת יש לטפל בUI
        //ChargeBattery זורקת אקספשן במידה והרכב לא מונע על ידי חשמל
        public void ChargeBattery(string i_LicensePlate, float i_HoursToAdd)
        {
            VehicleInGarage vehicleToCharge = FindVehicleByLicensePlate(i_LicensePlate);
            vehicleToCharge.ChargeBattery(i_HoursToAdd);
        }

        //סעיף 7 
        public void getVehicleDetails(string i_LicensePlate, ref StringBuilder o_VehicleDatails)
        {
            VehicleInGarage currentVehicle = FindVehicleByLicensePlate(i_LicensePlate);
            currentVehicle.GetVehicleDetails(ref o_VehicleDatails);
        }
    }
}
