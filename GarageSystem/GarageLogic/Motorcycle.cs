using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eLiscenceType m_LiscenceType;
        private int m_engineCapacity;

        internal enum eLiscenceType
        {
            A,
            A1,
            B1,
            BB,
        }

        // Properties
        public eLiscenceType LicenseType
        {
            get { return m_LiscenceType; }
            set { m_LiscenceType = value; }
        }

        public int EngineCapacity
        {
            get { return m_engineCapacity; }
            set { m_engineCapacity = value; }
        }

        // ctor
        public Motorcycle(string i_LicenseNumber, string i_ModelName, Engine.eEngineType i_EngineType, float i_CurrentAmountOfEnergyInPercantage)
            : base(i_LicenseNumber, i_ModelName, i_CurrentAmountOfEnergyInPercantage)
        {
            InitEngine(i_EngineType, i_CurrentAmountOfEnergyInPercantage);
        }

        internal override void InitEngine(Engine.eEngineType i_EngineType, float i_CurrentAmountOfEnergyInPercantage)
        {
            if (i_EngineType == Engine.eEngineType.Electric)
            {
                float currentAmountOfMinutes = i_CurrentAmountOfEnergyInPercantage * 150 / 100;
                this.Engine = new ElectricEngine(currentAmountOfMinutes, 150);
            }
            else
            {
                float currentAmountOfFuel = i_CurrentAmountOfEnergyInPercantage * 6.2f / 100;
                this.Engine = new FuelEngine(currentAmountOfFuel, 6.2f, FuelEngine.eFuelType.Octan98);
            }
        }

        public override List<string> GetAdditionalPropertiesList()
        {
            List<string> propertyList = new List<string>();
            string licenseType = string.Format(
@"MotorCycle License Type
Press 0 For: A
Press 1 For: A1
Press 2 For: B1
Press 3 For: BB");
            propertyList.Add(licenseType);
            propertyList.Add("Engine Capacity");
            return propertyList;
        }

        public override bool CheckValidProperty(string i_Property, string i_UserInput)
        {
            bool isValidProperty = false;
            string licenseType = string.Format(
@"MotorCycle License Type
Press 0 For: A
Press 1 For: A1
Press 2 For: B1
Press 3 For: BB");

            if (i_Property == licenseType)
            {
                int inputInteger = int.Parse(i_UserInput);
                eLiscenceType fuelType = (eLiscenceType)inputInteger;
                isValidProperty = Enum.IsDefined(typeof(eLiscenceType), fuelType);
            }
            else
            {
                bool isValidCapacity = int.TryParse(i_UserInput, out int capacity);
                isValidProperty = isValidCapacity;
            }

            return isValidProperty;
        }

        public override void UpdateAdditionalProperties(List<string> i_Answers, string i_ManufucturerName, float i_CurrentAirPressure)
        {
            try
            {
                this.EngineCapacity = int.Parse(i_Answers[1]);
                this.LicenseType = (eLiscenceType)Enum.Parse(typeof(eLiscenceType), i_Answers[0]);
                InitWheelsList(i_ManufucturerName, 2, i_CurrentAirPressure, 31);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw new FormatException("One of the inputs is not in the correct format of the motorcycle property.");
            }
        }

        public override bool CheckValidAirPressure(string i_UserInput)
        {
            bool isNumber = float.TryParse(i_UserInput, out float airPressure);
            bool isValidAirPressure = false;
            if (isNumber)
            {
                isValidAirPressure = airPressure > 0 && airPressure <= 31;
            }

            return isValidAirPressure;
        }

        public override string ToString()
        {
            StringBuilder motorcycleStr = new StringBuilder();
            string motorCycleDataStr = string.Format(
@"License Type: {0}
Engine Capacity: {1}",
this.LicenseType,
this.EngineCapacity);
            motorcycleStr.AppendLine(base.ToString());
            motorcycleStr.AppendLine(motorCycleDataStr);

            return motorcycleStr.ToString();
        }
    }
}
