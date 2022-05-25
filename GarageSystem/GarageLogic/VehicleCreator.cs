using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class VehicleCreator
    {
        public enum eNumberOfWheels
        {
            Motorcycle = 2,
            Car = 4,
            Truck = 6,
        }

        public enum eVehicleType
        {
            ElecticMotorcycle,
            FuelMotorcycle,
            ElectricCar,
            FuelCar,
            Truck,
        }

        public static Vehicle CreateNewVehicle(string i_LicenseNumber, eVehicleType i_VehicleType, string i_ModelName, float i_CurrentEnergyPercentage)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.ElecticMotorcycle:
                    {
                        newVehicle = new Motorcycle(i_LicenseNumber, i_ModelName, Engine.eEngineType.Electric, i_CurrentEnergyPercentage);
                        break;
                    }

                case eVehicleType.FuelMotorcycle:
                    {
                        newVehicle = new Motorcycle(i_LicenseNumber, i_ModelName, Engine.eEngineType.Fuel, i_CurrentEnergyPercentage);
                        break;
                    }

                case eVehicleType.ElectricCar:
                    {
                        newVehicle = new Car(i_LicenseNumber, i_ModelName, Engine.eEngineType.Electric, i_CurrentEnergyPercentage);
                        break;
                    }

                case eVehicleType.FuelCar:
                    {
                        newVehicle = new Car(i_LicenseNumber, i_ModelName, Engine.eEngineType.Fuel, i_CurrentEnergyPercentage);
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        newVehicle = new Truck(i_LicenseNumber, i_ModelName, Engine.eEngineType.Fuel, i_CurrentEnergyPercentage);
                        break;
                    }
            }

            return newVehicle;
        }
    }
}
