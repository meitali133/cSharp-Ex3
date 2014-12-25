using System;
using Ex03.GarageLogic;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public sealed class UserInterface
    {
        private Garage m_Garage = new Garage();

        internal enum eUsersInputYesOrNo
        {
            Yes = 1,
            No = 2
        }

        internal enum eJobToPerform
        {
            Insert = 1,
            LicensePlates = 2,
            ChangeStatus = 3,
            AirPressureTire = 4,
            Refuel = 5,
            ChargeElectric = 6,
            DisplayDetails = 7,
            Exit = 8
        }

        public UserInterface()
        {
            startWorkInTheGarage();
        }

        private void startWorkInTheGarage()
        {
            bool isAppEnd = false;
            while (!isAppEnd)
            {
                getJobFromUser(ref isAppEnd);
            }
        }

        private void getJobFromUser(ref bool i_isAppEnd)
        {
            string userChoice = string.Empty;
            bool isCoiceValid = false;
            string msg = string.Format(
@"Garage Service Menu

Please select the number of the job you want to to in the garage:
1. Insert new car to the garage.
2. View a list of license plate numbers of the vehicles in the garage.
3. Change the status of a car in the garage.
4. fill max air pressure to all the tires.
5. Refuel vehicle driven by fuel.
6. Charge electric vehicle.
7. Display all the data of car in the garage.
8. Exit");

            while (!isCoiceValid)
            {
                Console.Clear();
                Console.WriteLine(msg);
                try
                {
                    userChoice = Console.ReadLine();
                    eJobToPerform usersInputEnum = convertToTheMatchingEnum<eJobToPerform>(userChoice);
                    isCoiceValid = true;
                    DoTheRequestedJob(usersInputEnum, ref i_isAppEnd);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("{0}{1}please try again {1}press any key to continue..", ex.Message, Environment.NewLine);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("{0}{1}please try again {1}press any key to continue..", ex.Message, Environment.NewLine);
                }

                if (!isCoiceValid)
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void checkAndDoJob(eJobToPerform i_JobToDo, ref bool i_IsAppEnd)
        {
            switch (i_JobToDo)
            {
                case eJobToPerform.Insert:
                    {
                        // insertNewVehicleToTheGarage();
                        break;
                    }

                case eJobToPerform.LicensePlates:
                    {
                        displayLicensePlatesOfTheVehiclesInTheGarage();
                        break;
                    }

                case eJobToPerform.ChangeStatus:
                    {
                        changeVehicleStatus();
                        break;
                    }
                case eJobToPerform.AirPressureTire:
                    {
                        addMaxAirPressureToAllTire();
                        break;
                    }

                case eJobToPerform.Refuel:
                    {
                        refuelVehicle();
                        break;
                    }

                case eJobToPerform.ChargeElectric:
                    {
                        chargeVehicleBattery();
                        break;
                    }

                case eJobToPerform.DisplayDetails:
                    {
                        displayVehicelDatails();
                        break;
                    }

                case eJobToPerform.Exit:
                    {
                        i_IsAppEnd = true;
                        break;
                    }
            }
        }

        


        private void displayLicensePlatesOfTheVehiclesInTheGarage()
        {
            string userChoice = string.Empty;

            Console.WriteLine("Do you want to filter the license plates by their status?{0}", Environment.NewLine);
            printAllTheEnumNames<eUsersInputYesOrNo>();
            userChoice = Console.ReadLine();
            eUsersInputYesOrNo userInputEnum = convertToTheMatchingEnum<eUsersInputYesOrNo>(userChoice);
            if (userInputEnum == eUsersInputYesOrNo.No)
            {
                printAllLicensePlates();
            }
            else if (userInputEnum == eUsersInputYesOrNo.Yes)
            {
                Console.WriteLine("Insert status to print:{0}", Environment.NewLine);
                printAllTheEnumNames<VehicleInGarage.eVehicleStatus>();
                userChoice = Console.ReadLine();
                VehicleInGarage.eVehicleStatus userInputFilterEnum = convertToTheMatchingEnum<VehicleInGarage.eVehicleStatus>(userChoice);
                printAllLicensePlatesByFilter(userInputFilterEnum);
            }
        }

        private void printAllLicensePlates()
        {
            List<string> licensePlatesToPrint = m_Garage.getLicensePlateOfAllTheVehiclesInTheGarage();

            if (licensePlatesToPrint.Count == 0)
            {
                Console.WriteLine("Thers is no vehicles in the garage");
            }
            else
            {
                Console.WriteLine("List of all the license plates in the garage:");
                printLisencePlateNumbersList(licensePlatesToPrint);

            }
        }

        private void printAllLicensePlatesByFilter(VehicleInGarage.eVehicleStatus userInputFilterEnum)
        {
            List<string> licensePlatesToPrint = m_Garage.getVehiclesLicensePlateByStatus(userInputFilterEnum);

            if (licensePlatesToPrint.Count == 0)
            {
                Console.WriteLine("Thers is no vehicles in the garage in: '{0}' mode", userInputFilterEnum.ToString());
            }
            else
            {
                Console.WriteLine("List of all the license plates in the garage filter by {0} mode", userInputFilterEnum.ToString());
                printLisencePlateNumbersList(licensePlatesToPrint);
            }
        }

        private void printLisencePlateNumbersList(List<string> licensePlatesToPrint)
        {
            int numberOfCurrentCar = 1;

            foreach (string currentLicense in licensePlatesToPrint)
            {
                Console.WriteLine("{0}. {1}{2}", numberOfCurrentCar, currentLicense, Environment.NewLine);
                numberOfCurrentCar++;
            }
        }

        private void changeVehicleStatus()
        {
            try
            {
                string userChoice = string.Empty;
                string licensePlateString = getLicensePlateNumberFromUser();
                
                Console.WriteLine("Insert The new status of the vehicle :", Environment.NewLine);
                printAllTheEnumNames<VehicleInGarage.eVehicleStatus>();
                userChoice = Console.ReadLine();
                VehicleInGarage.eVehicleStatus newVehicleStatus = convertToTheMatchingEnum<VehicleInGarage.eVehicleStatus>(userChoice);
                m_Garage.ChangeVehicleStatusInGarage(licensePlateString, newVehicleStatus);
                Console.WriteLine("Vehicle status has been changed successfully! {0}", Environment.NewLine);
            }
            catch (ArgumentException ex)
            { // if the user press enter
                Console.WriteLine(ex.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void addMaxAirPressureToAllTire()
        {
            string licensePlateString = getLicensePlateNumberFromUser();
            m_Garage.AddMaxAirPressureToVehicle(licensePlateString);
            Console.WriteLine("Air pressure has been added to all the tires successfully{0}", Environment.NewLine);
        }

        private void refuelVehicle()
        {
            string licensePlateString = string.Empty;
            float amountOfFuel;
            string fuelTypeString = string.Empty;
            Fuel.eFuelType fuelType;
            
            licensePlateString = getLicensePlateNumberFromUser();
            fuelType = getFuelTypeFromUser();
            amountOfFuel = getTheAmountOfFuelFromUser();
            m_Garage.RefuleVehicle(licensePlateString, fuelType, amountOfFuel);
            System.Console.WriteLine("Tank has been refueled successfuly!{0}", Environment.NewLine);
        }

        private Fuel.eFuelType getFuelTypeFromUser()
        {
            string fuelTypeString = string.Empty;
            Fuel.eFuelType fuelType;

            Console.WriteLine("Choose The fuel type fuel type :");
            printAllTheEnumNames<Fuel.eFuelType>();
            fuelTypeString = Console.ReadLine();
            fuelType = convertToTheMatchingEnum<Fuel.eFuelType>(fuelTypeString);

            return fuelType;
        }

        private float getTheAmountOfFuelFromUser()
        {
            string amountOfFuelString = string.Empty;
            float amountOfFuel;
            bool isValidInput = false;

            do
            {
                System.Console.WriteLine("Enter the amount you want to fill: ");
                amountOfFuelString = Console.ReadLine();
                isValidInput = float.TryParse(amountOfFuelString, out amountOfFuel);
                if (!isValidInput)
                {
                    Console.WriteLine("Invlid Input, please try again");
                }
            } while (!isValidInput);

            return amountOfFuel;
        }

        private void chargeVehicleBattery()
        {
            string licensePlateString = string.Empty;
            string minutesToChargeString = string.Empty;
            float minutesToCharge;
            
            licensePlateString = getLicensePlateNumberFromUser();
            minutesToCharge = getMinutesToChargeFromUser();
            m_Garage.ChargeBattery(licensePlateString, (float)(minutesToCharge / 60));
            Console.WriteLine("Battery has been charged successfully!{0}", Environment.NewLine);
        }

        private float getMinutesToChargeFromUser()
        {
            string minutesToChargeString = string.Empty;
            float minutesToCharge;
            bool isValidInput = false;

            do
            {
                Console.WriteLine("Enter the minutes to charge : ");
                minutesToChargeString = Console.ReadLine();
                isValidInput = float.TryParse(minutesToChargeString, out minutesToCharge);
                if (!isValidInput)
                {
                    Console.WriteLine("Invlid Input, please try again");
                }
            }
            while (!isValidInput);

            return minutesToCharge;
        }


        ///////צריך איכשהו שהמתודה האבסטרקטית תעבוד..... לא יודעת עוד איך 
        ///    m_EnergySource.GetEnergySourceDetails(ref o_VehicleDetails);
        ///    במתודה במחלקת VEHICLE צריך שזה יעבוד לפי הפולימורפיזם 
        ///    צריך לראות שבאמת עשינו את כל הנתונים!!!!!!!
        private void displayVehicelDatails()
        {
            StringBuilder vehicleDetails = new StringBuilder();
            string licensePlateString = getLicensePlateNumberFromUser();
            m_Garage.getVehicleDetails(licensePlateString, ref vehicleDetails);
        }

        private T convertToTheMatchingEnum <T>(string i_UserChoice)
        {
            T usersInputEnum;

            try
            {
                usersInputEnum = (T)Enum.Parse(typeof(T), i_UserChoice);
            }
            catch
            {
                throw new ArgumentException("Invalid Choice");
            }

            if (Enum.IsDefined(typeof(T), usersInputEnum) == false)
            {
                throw new ArgumentException("Invalid Choice");
            }

            return usersInputEnum;
        }

        private string getLicensePlateNumberFromUser()
        {
            string licensePlateFromUser = string.Empty;

            Console.WriteLine("Please insert the license plate number of the vehicle: ");
            licensePlateFromUser = Console.ReadLine();

            return licensePlateFromUser;
        }

        private void DoTheRequestedJob(eJobToPerform i_JobToDo, ref bool i_IsAppEnd)
        {
            try
            {
                checkAndDoJob(i_JobToDo, ref i_IsAppEnd);
                
            }
            catch (FormatException exFormatException)
            {
                Console.WriteLine(exFormatException.Message);
            }
            catch (ArgumentException exArgException)
            {
                Console.WriteLine(exArgException.Message);
            }
            catch (ValueOutOfRangeException exValOutOfRangeException)
            {
                Console.WriteLine(exValOutOfRangeException.Message);
                Console.WriteLine("Values are between {0} and {1}", exValOutOfRangeException.MinValue, exValOutOfRangeException.MaxValue);
            }
            catch (System.Exception exParseException)
            {
                Console.WriteLine(exParseException.Message);
            }
            finally
            {
                if (!i_IsAppEnd)
                {
                    System.Console.WriteLine("{0}Press any key to continue...", Environment.NewLine);
                    System.Console.ReadKey();
                    getJobFromUser(ref i_IsAppEnd);
                }
            }
        }

        private void insertNewVehicleToTheGarage()
        {
            string plateNumberString = string.Empty;

            plateNumberString = Console.ReadLine();
        }

        private void printAllTheEnumNames<T>()
        {
            var names = Enum.GetNames(typeof(T));
            int i = 1;

            foreach (var name in names)
            {
                Console.WriteLine("{0}) {1}.", i.ToString(), name.ToString());
                i++;
            }
        }
    }
}
