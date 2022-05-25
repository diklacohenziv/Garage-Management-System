using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_LicenseNumber;
        private readonly string r_ModelName;
        private float m_CurrentEnergyPercentage;
        private List<Wheel> m_ListOfWheels;
        protected Engine m_Engine = null;

        // Properties
        public string LicenseNumber
        {
            get
            {
                return this.r_LicenseNumber;
            }
        }

        public string ModelName
        {
            get
            {
                return this.r_ModelName;
            }
        }

        public float CurrentEnergyPercentage
        {
            get { return this.m_CurrentEnergyPercentage; }
            set { this.m_CurrentEnergyPercentage = value; }
        }

        public List<Wheel> ListOfWheels
        {
            get { return this.m_ListOfWheels; }
        }

        public Engine Engine
        {
            get { return this.m_Engine; }
            set { this.m_Engine = value; }
        }

        // Ctor
        protected Vehicle(string i_LicenseNumber, string i_ModelName, float i_CurrentEnergyPercentage)
        {
            this.r_LicenseNumber = i_LicenseNumber;
            this.r_ModelName = i_ModelName;
            this.m_CurrentEnergyPercentage = i_CurrentEnergyPercentage;
        }

        internal void InitWheelsList(string i_WheelManufacturer, int i_NumberOfWheels, float i_CurrentAmountOfAirPressur, float i_MaxAmuntOfAirPressuer)
        {
            m_ListOfWheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheel newWheel = new Wheel(i_WheelManufacturer, i_CurrentAmountOfAirPressur, i_MaxAmuntOfAirPressuer);
                this.m_ListOfWheels.Add(newWheel);
            }
        }

        internal abstract void InitEngine(Engine.eEngineType i_EngineType, float i_EnergyPercentageLeft);

        public abstract List<string> GetAdditionalPropertiesList();

        public abstract void UpdateAdditionalProperties(List<string> additionalProperties, string i_ManufucturerName, float i_CurrentAirPressure);

        public abstract bool CheckValidProperty(string i_PropertyTypeToCheck, string i_UserInput);

        public abstract bool CheckValidAirPressure(string i_UserInput);

        public void FillEnergy(float i_AmountOfEnergyToFill)
        {
            this.Engine.FillEngineEnergy(i_AmountOfEnergyToFill);
            this.CurrentEnergyPercentage = (this.Engine.CurrentAmountOfEnergy / this.Engine.MaxEnergyAmount) * 100;
        }

        public override bool Equals(object i_Object)
        {
            bool isEquals = false;

            Vehicle vehicletoCompareTo = i_Object as Vehicle;
            if (vehicletoCompareTo != null)
            {
                isEquals = LicenseNumber == vehicletoCompareTo.LicenseNumber;
            }

            return isEquals;
        }

        public override int GetHashCode()
        {
            return LicenseNumber.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder vehicleDataStr = new StringBuilder();

            string vehicleGenericInfo = string.Format(
@"License number: {0} 
Model name: {1}
Current amount of energy in percentege {2}",
LicenseNumber,
ModelName,
CurrentEnergyPercentage);

            vehicleDataStr.AppendLine(vehicleGenericInfo);
            vehicleDataStr.AppendLine(this.ListOfWheels[0].ToString());
            vehicleDataStr.AppendLine(this.Engine.ToString());
            return vehicleDataStr.ToString();
        }
    }
}
