using System;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public sealed class UserInterface
    {
        //private Garage = new Garage();

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
                    eJobToPerform usersInputEnum = ConvertToEnumJobToDo(userChoice);
                    isCoiceValid = true;
                    DoUsersRequest(usersInputEnum, ref i_isAppEnd);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message + "{0}please try again {0}press any key to continue..", Environment.NewLine);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message + "{0}please try again {0}press any key to continue..", Environment.NewLine);
                }

                if (!isCoiceValid)
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private eJobToPerform ConvertToEnumJobToDo(string i_UserJob)
        {
            eJobToPerform usersInputEnum;

            try
            {
                usersInputEnum = (eJobToPerform)Enum.Parse(typeof(eJobToPerform), i_UserJob);
            }
            catch ///לא בטוחה שזה מה שצריך לזרוק בהתאם להוראות
            { // because the user can press enter
                throw new ArgumentException("Invalid Choice!");
            }

            if (!Enum.IsDefined(typeof(eJobToPerform), usersInputEnum))
            {
                throw new FormatException("Invalid Choice!");
            }

            return usersInputEnum;
        }

        private void DoUsersRequest(eJobToPerform i_Job, ref bool i_isAppEnd)
        {
            try
            {
                switch (i_Job)
                {
                    case eJobToPerform.Insert:
                        {
                            InsertNewClient();
                            break;
                        }

                    case eJobToPerform.LicensePlates:
                        {
                            DisplayLicense();
                            break;
                        }

                    case eJobToPerform.ChangeStatus:
                        {
                            ChangeStatusOfClient();
                            break;
                        }
                    case eJobToPerform.AirPressureTire:
                        {
                            AirInflatingToMax();
                            break;
                        }

                    case eJobToPerform.Refuel:
                        {
                            RefuelVehicle();
                            break;
                        }

                    case eJobToPerform.ChargeElectric:
                        {
                            ChargeCarBattery();
                            break;
                        }

                    case eJobToPerform.DisplayDetails:
                        {
                            DisplayVehicelData();
                            break;
                        }

                    case eJobToPerform.Exit:
                        {
                            i_isAppEnd = true;
                            break;
                        }
                }
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
                if (!i_isAppEnd)
                {
                    System.Console.WriteLine("{0}Press any key to continue...", Environment.NewLine);
                    System.Console.ReadKey();
                    getJobFromUser(ref i_isAppEnd);
                }
            }
        }

        private void insertNewVehicleToTheGarage()
        {
            string plateNumberString = string.Empty;

            plateNumberString = Console.ReadLine();
        }

        private void getPlateNumberOfTheVehicle()
        {
            Console.WriteLine("Please enter the plate number of the vehicle");
        }
    }
}
