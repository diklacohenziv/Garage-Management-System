using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_ContainCooledCargo;
        private float m_TrunkVolume;

        // Prpoperties
        public bool IsColdTank
        {
            get { return m_ContainCooledCargo; }
            set { m_ContainCooledCargo = value; }
        }

        public float TrunkVolume
        {
            get { return m_TrunkVolume; }
            set { m_TrunkVolume = value; }
        }

        // Ctor
        public Truck(string i_LicenseNumber, string i_ModelName, Engine.eEngineType i_EngineType, float i_CurrentAmountOfEnergyInPercantage)
        : base(i_LicenseNumber, i_ModelName, i_CurrentAmountOfEnergyInPercantage)
        {
            InitEngine(i_EngineType, i_CurrentAmountOfEnergyInPercantage);
        }

        internal override void InitEngine(Engine.eEngineType i_EngineType, float i_CurrentAmountOfEnergyInPercantage)
        {
            this.Engine = new FuelEngine(i_CurrentAmountOfEnergyInPercantage * 120 / 100, 120, FuelEngine.eFuelType.Soler);
        }

        public override List<string> GetAdditionalPropertiesList()
        {
            List<string> propertyList = new List<string>();
            propertyList.Add("Is Contain cooled cargo Y/N");
            propertyList.Add("Cargo Tank Volume");
            return propertyList;
        }

        public override bool CheckValidProperty(string i_Property, string i_UserInput)
        {
            bool isValidProperty = false;
            if (i_Property == "Is Contain cooled cargo Y/N")
            {
                isValidProperty = i_UserInput.Equals("Y") || i_UserInput.Equals("N");
            }
            else
            {
                bool isValidCargoVolume = float.TryParse(i_UserInput, out float cargoVolume);
                isValidProperty = isValidCargoVolume;
            }

            return isValidProperty;
        }

        public override void UpdateAdditionalProperties(List<string> i_Answers, string i_ManufucturerName, float i_CurrentAirPressure)
        {
            try
            {
                if (i_Answers[0].Equals("Y"))
                {
                    this.IsColdTank = true;
                }
                else
                {
                    this.IsColdTank = false;
                }

                this.TrunkVolume = float.Parse(i_Answers[1]);
                InitWheelsList(i_ManufucturerName, 16, i_CurrentAirPressure, 24);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw new FormatException("One of the inputs is not in the correct format of the truck property.");
            }
        }

        public override bool CheckValidAirPressure(string i_UserInput)
        {
            bool isNumber = float.TryParse(i_UserInput, out float airPressure);
            bool isValidAirPressure = false;
            if (isNumber)
            {
                isValidAirPressure = airPressure > 0 && airPressure <= 24;
            }

            return isValidAirPressure;
        }

        public override string ToString()
        {
            StringBuilder truckStr = new StringBuilder();
            string truckDataStr = string.Format(
@"contained cooled cargo: {0}
Cargo volume: {1}",
this.IsColdTank,
this.TrunkVolume);
            truckStr.AppendLine(base.ToString());
            truckStr.AppendLine(truckDataStr);

            return truckStr.ToString();
        }
    }
}
