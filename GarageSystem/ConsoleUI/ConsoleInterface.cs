using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class ConsoleInterface
    {
        private readonly Garage r_Garage;

        public Garage Garage
        {
            get { return r_Garage; }
        }

        private enum eTypeOfAction
        {
            InsertNewVehicle,
            DisplayLicenseNumbers,
            ChangeVehicleStatus,
            InflateTiresToMax,
            RefuelVehicale,
            ChargeVehicale,
            DisplayVehicleInformation,
            EndOfDay,
        }

        // ctor
        public ConsoleInterface()
        {
            this.r_Garage = new Garage();
        }

        private static void printMenu()
        {
            string menuActions = string.Format(
@"
**************************************************************************************************
******************************** WELCOME TO THE BEST GARAGE EVER! ********************************
**************************************************************************************************
 __________________________________________________________________________________________________
| Please choose your desired action (a number between {0} to {7} ):                                   |
|_________________________________________________________________________________________________|
|                                                                                                 |
| press {0} to: Insert a new vehicle into the garage                                                |
| press {1} to: Display a list of license numbers currently in the garage (filterd or unfiltered)   |
| press {2} to: Change Vehicle's status                                                             |
| press {3} to: Inflate vehicle tires to maximum                                                    |
| press {4} to: Refuel a Fuel-based vehicle                                                         |
| press {5} to: Charge an electric-based vehicle                                                    |
| press {6} to: Display specific vehicle information                                                |
| press {7} to: End of day and exit                                                                 |
|_________________________________________________________________________________________________|

Your answer:",
(int)eTypeOfAction.InsertNewVehicle,
(int)eTypeOfAction.DisplayLicenseNumbers,
(int)eTypeOfAction.ChangeVehicleStatus,
(int)eTypeOfAction.InflateTiresToMax,
(int)eTypeOfAction.RefuelVehicale,
(int)eTypeOfAction.ChargeVehicale,
(int)eTypeOfAction.DisplayVehicleInformation,
(int)eTypeOfAction.EndOfDay);

            Console.WriteLine(menuActions);
            Console.WriteLine();
        }

        private static bool checkIfEnumIsValid(Type i_EnumType, string i_Input)
        {
            bool isValid = false;

            if (int.TryParse(i_Input, out int inputResult))
            {
                isValid = Enum.IsDefined(i_EnumType, inputResult);
            }

            return isValid;
        }

        private static void printListOfEnum(Type i_TypeOfEnum, string i_Message)
        {
            string[] types = Enum.GetNames(i_TypeOfEnum);
            Console.WriteLine(Environment.NewLine + i_Message);

            for (int i = 0; i < types.Length; ++i)
            {
                Console.WriteLine("Press '{0}' for {1}", i, types[i]);
            }

            Console.WriteLine(Environment.NewLine);
        }

        private static void printReturnToMenuMessage()
        {
            Console.WriteLine(string.Format(
@"
___________________________________________________________________________________________

*******************
Return to menu? 
Press ANY KEY to continue
*******************"));

            Console.ReadLine();
        }

        private static eTypeOfAction getActionFromUser()
        {
            printMenu();
            string typeOfActionStr = Console.ReadLine();

            while (!checkIfEnumIsValid(typeof(eTypeOfAction), typeOfActionStr))
            {
                Console.WriteLine(Environment.NewLine + "This is not a valid choise for action. Please try again.");
                typeOfActionStr = Console.ReadLine();
            }

            eTypeOfAction typeOfAction = (eTypeOfAction)Enum.Parse(typeof(eTypeOfAction), typeOfActionStr);

            return typeOfAction;
        }

        private static string getManufacturerName()
        {
            Console.WriteLine(Environment.NewLine + "Please enter the wheels manufacturer name: ");
            string manufacturerName = Console.ReadLine();
            return manufacturerName;
        }

        private static float getEnergyPercentage()
        {
            Console.WriteLine(Environment.NewLine + "Please enter your vehicle's energy percentage left (between 0 - 100): ");
            string energyLeftInput = Console.ReadLine();

            bool isNumber = float.TryParse(energyLeftInput, out float energyPercantage);
            bool isValidPercentage = isNumber && (energyPercantage >= 0 && energyPercantage <= 100);

            while (!isValidPercentage)
            {
                Console.WriteLine(Environment.NewLine + "Invalid percentage, please try again :");
                energyLeftInput = Console.ReadLine();
                isNumber = float.TryParse(energyLeftInput, out energyPercantage);
                isValidPercentage = isNumber && (energyPercantage >= 0 && energyPercantage <= 100);
            }

            return float.Parse(energyLeftInput);
        }

        private static string getCustomerName()
        {
            Console.WriteLine(Environment.NewLine + "Please write the customer's name: ");
            string costumerName = Console.ReadLine();

            return costumerName;
        }

        private static string getCustomerPhoneNumber()
        {
            Console.WriteLine(Environment.NewLine + "Please write the customer phone number (digits only): ");
            string costumerPhoneNumber = Console.ReadLine();
            bool isValidPhoneNumber = int.TryParse(costumerPhoneNumber, out int phoneNumber);

            while (!isValidPhoneNumber)
            {
                Console.WriteLine(Environment.NewLine + "Invalid phone number. Please try again.");
                costumerPhoneNumber = Console.ReadLine();
                isValidPhoneNumber = int.TryParse(costumerPhoneNumber, out phoneNumber);
            }

            return costumerPhoneNumber;
        }

        private static VehicleCreator.eVehicleType getVehicleType()
        {
            printListOfEnum(typeof(VehicleCreator.eVehicleType), "Please enter the type of the vehicle:");
            string vehicleTypeStr = Console.ReadLine();
            while (!checkIfEnumIsValid(typeof(VehicleCreator.eVehicleType), vehicleTypeStr))
            {
                Console.WriteLine(Environment.NewLine + "This is not a valid choise for vehicle. Please try again.");
                vehicleTypeStr = Console.ReadLine();
            }

            int vehicleTypeNumber = int.Parse(vehicleTypeStr);
            VehicleCreator.eVehicleType vehicleType = (VehicleCreator.eVehicleType)vehicleTypeNumber;
            return vehicleType;
        }

        private static string getLicenseNumber()
        {
            Console.WriteLine(Environment.NewLine + "Please enter the vehicle's license number:");
            string licenseNumber = Console.ReadLine();
            return licenseNumber;
        }

        private static string getModelName()
        {
            Console.WriteLine(Environment.NewLine + "Please enter the model name of the vehicle:");
            string vehicleModelName = Console.ReadLine();
            return vehicleModelName;
        }

        private static float getAmountOfMinutesToAdd()
        {
            Console.WriteLine(Environment.NewLine + "Please enter the amount of minutes to add");
            string amountToFillStr = Console.ReadLine();
            bool isNumber = float.TryParse(amountToFillStr, out float amountToFill);
            while (!isNumber)
            {
                Console.WriteLine(Environment.NewLine + "this is not a valid input. please enter the amount of minutes to add");
                amountToFillStr = Console.ReadLine();
            }

            return amountToFill;
        }

        private static float getAmountOfFuelToAdd()
        {
            Console.WriteLine(Environment.NewLine + "Please enter the amount of fuel to add");
            string amountToFillStr = Console.ReadLine();
            bool isNumber = float.TryParse(amountToFillStr, out float amountToFill);
            while (!isNumber)
            {
                Console.WriteLine(Environment.NewLine + "this is not a valid input. please enter the amoung of fuel in liters");
                amountToFillStr = Console.ReadLine();
            }

            return amountToFill;
        }

        private static FuelEngine.eFuelType getFuelType()
        {
            printListOfEnum(typeof(FuelEngine.eFuelType), "Please Choose the fuel type:");
            string fuelTypeInput = Console.ReadLine();
            while (!checkIfEnumIsValid(typeof(FuelEngine.eFuelType), fuelTypeInput))
            {
                Console.WriteLine(Environment.NewLine + "This type of fuel des not fit the vehicle type of fuel.");
                fuelTypeInput = Console.ReadLine();
            }

            int fuelTypeNumber = int.Parse(fuelTypeInput);
            FuelEngine.eFuelType fuelType = (FuelEngine.eFuelType)fuelTypeNumber;

            return fuelType;
        }

        private static List<string> getAdditionalProperties(Vehicle i_Vehicle)
        {
            List<string> additionalProperties = i_Vehicle.GetAdditionalPropertiesList();
            List<string> answers = new List<string>();
            foreach (string additionalProperty in additionalProperties)
            {
                Console.WriteLine(Environment.NewLine + "Please enter the property " + additionalProperty + ":");
                string property = Console.ReadLine();
                while (!i_Vehicle.CheckValidProperty(additionalProperty, property))
                {
                    Console.WriteLine(Environment.NewLine + "This property value is not valid. Please try again");
                    property = Console.ReadLine();
                }

                answers.Add(property);
            }

            return answers;
        }

        private static void endOfDay()
        {
            Console.WriteLine(Environment.NewLine + "GoodBye!");
            Console.ReadLine();
        }

        internal void ManageGarage()
        {
            bool isEndOfDay = false;
            while (!isEndOfDay)
            {
                try
                {
                    eTypeOfAction typeOfAction = getActionFromUser();
                    makeAction(typeOfAction);
                    if (typeOfAction == eTypeOfAction.EndOfDay)
                    {
                        isEndOfDay = true;
                    }

                    printReturnToMenuMessage();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(Environment.NewLine + "*********************************************************************");
                    Console.WriteLine(exception.Message);
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                        Console.WriteLine(exception.InnerException.Message);
                    }

                    Console.WriteLine(Environment.NewLine + "*********************************************************************");
                }
            }
        }

        private void makeAction(eTypeOfAction i_TypeOfAction)
        {
            string licenseNumber = string.Empty;
            bool isLeagelToMakeOp = true;

            if (i_TypeOfAction != eTypeOfAction.InsertNewVehicle && i_TypeOfAction != eTypeOfAction.DisplayLicenseNumbers)
            {
                licenseNumber = getLicenseNumber();
                isLeagelToMakeOp = Garage.AllGarageVehicles.ContainsKey(licenseNumber);
            }

            if (isLeagelToMakeOp)
            {
                switch (i_TypeOfAction)
                {
                    case eTypeOfAction.InsertNewVehicle:
                        {
                            InsertNewVehicle();
                            break;
                        }

                    case eTypeOfAction.DisplayLicenseNumbers:
                        {
                            displayLicenseNumbers();
                            break;
                        }

                    case eTypeOfAction.ChangeVehicleStatus:
                        {
                            changeVehicleStatus(licenseNumber);
                            break;
                        }

                    case eTypeOfAction.InflateTiresToMax:
                        {
                            inflateTiresToMax(licenseNumber);
                            break;
                        }

                    case eTypeOfAction.RefuelVehicale:
                        {
                            refuelVehicle(licenseNumber);
                            break;
                        }

                    case eTypeOfAction.ChargeVehicale:
                        {
                            chargeVehicle(licenseNumber);
                            break;
                        }

                    case eTypeOfAction.DisplayVehicleInformation:
                        {
                            displayVehicleInformation(licenseNumber);
                            break;
                        }

                    case eTypeOfAction.EndOfDay:
                        {
                            endOfDay();
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Your license number was NOT found.");
            }
        }

        internal void InsertNewVehicle()
        {
            string licenseNumber = getLicenseNumber();
            if (this.r_Garage.AllGarageVehicles.ContainsKey(licenseNumber))
            {
                Console.WriteLine(Environment.NewLine + "This Vehicle already exist. Changing the status to InRepair.");
                r_Garage.AllGarageVehicles[licenseNumber].VehicleStatus = GarageVehicle.eVehicleStatus.inRepair;
            }
            else
            {
                string customerName = getCustomerName();
                string customerPhoneNumber = getCustomerPhoneNumber();
                VehicleCreator.eVehicleType vehicleType = getVehicleType();
                string modelName = getModelName();
                float currentEnergyPercentage = getEnergyPercentage();
                Vehicle newVehicle = VehicleCreator.CreateNewVehicle(licenseNumber, vehicleType, modelName, currentEnergyPercentage);
                List<string> additionalProperties = getAdditionalProperties(newVehicle);
                string wheelsManufacturerName = getManufacturerName();
                float currentAirPressure = getAirPressure(newVehicle);
                newVehicle.UpdateAdditionalProperties(additionalProperties, wheelsManufacturerName, currentAirPressure);
                GarageVehicle newGarageVehicle = new GarageVehicle(customerName, customerPhoneNumber, newVehicle);
                r_Garage.AllGarageVehicles.Add(licenseNumber, newGarageVehicle);
            }

            Console.WriteLine(string.Format(@"
***********************************
Your vehicle inserted secsussfuly!
**********************************"));
        }

        private float getAirPressure(Vehicle i_Vehicle)
        {
            Console.WriteLine(Environment.NewLine + "Please enter the wheels current air pressure:");
            string currentAirPressure = Console.ReadLine();
            bool isValidAirPressureForVehicleType = i_Vehicle.CheckValidAirPressure(currentAirPressure);
            while (!isValidAirPressureForVehicleType)
            {
                Console.WriteLine(Environment.NewLine + "Your input is not a number. please try again");
                currentAirPressure = Console.ReadLine();
                isValidAirPressureForVehicleType = i_Vehicle.CheckValidAirPressure(currentAirPressure);
            }

            return float.Parse(currentAirPressure);
        }

        private void displayLicenseNumbers()
        {
            string unfilterdOrNot = string.Format(
@"
Which license numbers list would you like to get?
-------------------------------------------------
Press 0 for : Unfilterd list
Press 1 for : Filterd list");
            Console.WriteLine(Environment.NewLine + unfilterdOrNot);

            string choiceOfListInput = Console.ReadLine();

            while (!choiceOfListInput.Equals("0") && !choiceOfListInput.Equals("1"))
            {
                Console.WriteLine(string.Format(
@"Invalid request. Please try again.

{0}",
unfilterdOrNot));
                choiceOfListInput = Console.ReadLine();
            }

            if (choiceOfListInput.Equals("0"))
            {
                printAllLicenseNumber();
            }
            else
            {
                printFilterdLicenseNumber();
            }
        }

        private void printAllLicenseNumber()
        {
            Console.WriteLine(string.Format(
@"
List of all vehicles license numbers:
-------------------------------------"));
            foreach (KeyValuePair<string, GarageVehicle> garageVehicle in r_Garage.AllGarageVehicles)
            {
                Console.WriteLine(garageVehicle.Key);
            }
        }

        private void printFilterdLicenseNumber()
        {
            printListOfEnum(typeof(GarageVehicle.eVehicleStatus), "Enter the corresponding number of your desired list: ");
            string filterdChoiceInput = Console.ReadLine();
            while (!checkIfEnumIsValid(typeof(GarageVehicle.eVehicleStatus), filterdChoiceInput))
            {
                Console.WriteLine(Environment.NewLine + "Invalid request. Please trt again.");
                filterdChoiceInput = Console.ReadLine();
            }

            GarageVehicle.eVehicleStatus filterChoice = (GarageVehicle.eVehicleStatus)Enum.Parse(typeof(GarageVehicle.eVehicleStatus), filterdChoiceInput);
            Console.WriteLine(string.Format(
            @"
List of all vehicles license numbers:
-------------------------------------"));
            foreach (KeyValuePair<string, GarageVehicle> garageVehicle in r_Garage.AllGarageVehicles)
            {
                if (garageVehicle.Value.VehicleStatus == filterChoice)
                {
                    Console.WriteLine(Environment.NewLine + garageVehicle.Key);
                }
            }
        }

        private void changeVehicleStatus(string i_LicenseNumber)
        {
            Console.WriteLine(Environment.NewLine + "Your current vehicle status is: " + Garage.AllGarageVehicles[i_LicenseNumber].VehicleStatus);
            string requestForNewStatus = "To what status would you like to change it?";
            printListOfEnum(typeof(GarageVehicle.eVehicleStatus), requestForNewStatus);
            string newStstusStr = Console.ReadLine();
            while (!checkIfEnumIsValid(typeof(GarageVehicle.eVehicleStatus), newStstusStr))
            {
                Console.WriteLine(Environment.NewLine + "Invalid request. Please try again.");
                printListOfEnum(typeof(GarageVehicle.eVehicleStatus), requestForNewStatus);
                newStstusStr = Console.ReadLine();
            }

            GarageVehicle.eVehicleStatus newGarageStatus = (GarageVehicle.eVehicleStatus)Enum.Parse(typeof(GarageVehicle.eVehicleStatus), newStstusStr);

            Garage.ChangeStatus(i_LicenseNumber, newGarageStatus);
            Console.WriteLine(Environment.NewLine + "Your vehicle status changed successfully to: " + newStstusStr);
        }

        private void inflateTiresToMax(string i_LicenseNumber)
        {
            bool isPerfectCondition = true;
            Vehicle vehicleToInflateTires = r_Garage.AllGarageVehicles[i_LicenseNumber].Vehicle;

            foreach (Wheel currentWheel in vehicleToInflateTires.ListOfWheels)
            {
                if (!currentWheel.CurrentAirPressure.Equals(currentWheel.MaxAirPressure))
                {
                    r_Garage.InflateTires(i_LicenseNumber);
                    isPerfectCondition = false;
                    break;
                }
            }

            if (!isPerfectCondition)
            {
                Console.WriteLine(string.Format(
@"You had some wheels whit low air pressure!
But dont worry...
we inflated your wheels as needed.
Updated wheels air pressure:"));

                foreach (Wheel currentWheel in vehicleToInflateTires.ListOfWheels)
                {
                    Console.WriteLine(currentWheel.CurrentAirPressure);
                }

                Console.WriteLine(Environment.NewLine + "Now, you can drive home safely.");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Your wheels are in perfect air pressure condition and do not need to be inflatd.");
            }
        }

        private void chargeVehicle(string i_LicenseNumber)
        {
            if (Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.Engine is ElectricEngine)
            {
                float amountOfMinutesToAdd = getAmountOfMinutesToAdd();
                ElectricEngine vehicleElectricEngine = Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.Engine as ElectricEngine;
                if (amountOfMinutesToAdd + vehicleElectricEngine.CurrentAmountOfEnergy <= vehicleElectricEngine.MaxEnergyAmount)
                {
                    string chargeMsg = string.Format(
@"Current amount of energy in percentage : {0}
Current amount of energy in minutes: {1}",
Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.CurrentEnergyPercentage,
vehicleElectricEngine.CurrentAmountOfEnergy);
                    Console.WriteLine(Environment.NewLine + chargeMsg);
                    Garage.ChargeVehicle(i_LicenseNumber, amountOfMinutesToAdd);

                    string newChargeMsg = string.Format(
@"New amount of energy in percentage : {0}
New amount of energy in minutes: {1}",
Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.CurrentEnergyPercentage,
vehicleElectricEngine.CurrentAmountOfEnergy);

                    Console.WriteLine(Environment.NewLine + newChargeMsg);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "To much minutes to add. please try again");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "This is not an electric based vehicle");
                Console.ReadLine();
            }
        }

        private void refuelVehicle(string i_LicenseNumber)
        {
            if (Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.Engine is FuelEngine)
            {
                FuelEngine.eFuelType fuelType = getFuelType();
                float amountOfFuelToAdd = getAmountOfFuelToAdd();
                FuelEngine vehicleFuelEngine = Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.Engine as FuelEngine;
                if (vehicleFuelEngine.CurrentAmountOfEnergy + amountOfFuelToAdd <= vehicleFuelEngine.MaxEnergyAmount)
                {
                    string fuelMsg = string.Format(
@"Current amount of Fuel in percentage : {0}
Current amount of fuel in liter: {1}",
Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.CurrentEnergyPercentage,
vehicleFuelEngine.CurrentAmountOfEnergy);
                    Console.WriteLine(Environment.NewLine + fuelMsg);
                    Garage.FuelVehicle(i_LicenseNumber, amountOfFuelToAdd, fuelType);
                    string newFuelMsg = string.Format(
@"New Amount Of Fuel in percentage: {0}
New amount of fuel in liter: {1}",
Garage.AllGarageVehicles[i_LicenseNumber].Vehicle.CurrentEnergyPercentage,
vehicleFuelEngine.CurrentAmountOfEnergy);
                    Console.WriteLine(Environment.NewLine + newFuelMsg);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Too much Fuel to fill. please try again");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "This vehicle is not fuel based vehicle.");
                Console.ReadLine();
            }
        }

        private void displayVehicleInformation(string i_LicenseNumber)
        {
            Console.WriteLine(Environment.NewLine + Garage.AllGarageVehicles[i_LicenseNumber].ToString());
        }
    }
}

