using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Car : Vehicle
    {
        private int m_NumberOfDoors;
        private eColorOfCar m_CarColor;

        internal enum eColorOfCar
        {
            red,
            white,
            green,
            blue,
        }

        // Properties
        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public eColorOfCar CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        // Ctor
        public Car(string i_LicenseNumber, string i_ModelName, Engine.eEngineType i_EngineType, float i_CurrentAmountOfEnergyInPercantage)
            : base(i_LicenseNumber, i_ModelName, i_CurrentAmountOfEnergyInPercantage)
        {
            InitEngine(i_EngineType, i_CurrentAmountOfEnergyInPercantage);
        }

        internal override void InitEngine(Engine.eEngineType i_EngineType, float i_CurrentAmountOfEnergyInPercantage)
        {
            if (i_EngineType == Engine.eEngineType.Electric)
            {
                float currentAmountOfMinutes = i_CurrentAmountOfEnergyInPercantage * 200 / 100;
                this.Engine = new ElectricEngine(currentAmountOfMinutes, 200);
            }
            else
            {
                float currentAmountOfFuel = i_CurrentAmountOfEnergyInPercantage * 38 / 100;
                this.Engine = new FuelEngine(currentAmountOfFuel, 38, FuelEngine.eFuelType.Octan95);
            }
        }

        public override List<string> GetAdditionalPropertiesList()
        {
            List<string> propertyList = new List<string>();
            string carColorProperty = string.Format(
@"Car Color
Press 0 For : Red
Press 1 For : White
Press 2 For : Green
Press 3 For : Blue");
            propertyList.Add(carColorProperty);
            propertyList.Add("Number Of Doors (2 / 3 / 4 / 5)");
            return propertyList;
        }

        public override bool CheckValidProperty(string i_Property, string i_UserInput)
        {
            string carColorProperty = string.Format(
@"Car Color
Press 0 For : Red
Press 1 For : White
Press 2 For : Green
Press 3 For : Blue");
            bool isValidProperty = false;
            if (i_Property == carColorProperty)
            {
                int inputInteger = int.Parse(i_UserInput);
                eColorOfCar carColor = (eColorOfCar)inputInteger;
                isValidProperty = Enum.IsDefined(typeof(eColorOfCar), carColor);
            }
            else
            {
                bool isValidDoorNum = int.TryParse(i_UserInput, out int numOfDoors);
                isValidProperty = isValidDoorNum && (numOfDoors > 1 && numOfDoors < 6);
            }

            return isValidProperty;
        }

        public override void UpdateAdditionalProperties(List<string> i_Answers, string i_ManufucturerName, float i_CurrentAirPressure)
        {
            try
            {
                this.NumberOfDoors = int.Parse(i_Answers[1]);
                this.CarColor = (eColorOfCar)Enum.Parse(typeof(eColorOfCar), i_Answers[0]);
                InitWheelsList(i_ManufucturerName, 4, i_CurrentAirPressure, 29);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("One of the inputs is not in the correct format of the car property.");
            }
            catch (FormatException)
            {
                throw new FormatException("One of the inputs is not in the correct format of the car property.");
            }
        }

        public override bool CheckValidAirPressure(string i_UserInput)
        {
            bool isNumber = float.TryParse(i_UserInput, out float airPressure);
            bool isValidAirPressure = false;
            if (isNumber)
            {
                isValidAirPressure = airPressure > 0 && airPressure <= 29;
            }

            return isValidAirPressure;
        }

        public override string ToString()
        {
            StringBuilder carStr = new StringBuilder();
            string carDataStr = string.Format(
@"Number Of Doors: {0}
Car Color: {1}",
this.NumberOfDoors,
this.CarColor);
            carStr.AppendLine(base.ToString());
            carStr.AppendLine(carDataStr);

            return carStr.ToString();
        }
    }
}
