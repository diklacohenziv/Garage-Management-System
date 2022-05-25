using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> r_AllGarageVehicles;

        public Dictionary<string, GarageVehicle> AllGarageVehicles
        {
            get { return r_AllGarageVehicles; }
        }

        public Garage()
        {
            this.r_AllGarageVehicles = new Dictionary<string, GarageVehicle>();
        }

        // This function gets License number and new status to change and update this vehicle status
        public void ChangeStatus(string i_LicenseNumber, GarageVehicle.eVehicleStatus i_NewStatus)
        {
            AllGarageVehicles[i_LicenseNumber].VehicleStatus = i_NewStatus;
        }

        // This function gets a License Number and inflate his tires as needed to max air pressure
        public void InflateTires(string i_LicenseNumber)
        {
            foreach (Wheel currentWheel in AllGarageVehicles[i_LicenseNumber].Vehicle.ListOfWheels)
            {
                if (!currentWheel.CurrentAirPressure.Equals(currentWheel.MaxAirPressure))
                {
                    float airAmountToAdd = currentWheel.MaxAirPressure - currentWheel.CurrentAirPressure;

                    currentWheel.InflateOneTire(airAmountToAdd);
                }
            }
        }

        // This function gets License number, fuel type and amount of fuel to fill and fuel this fuel based vehicle
        public void FuelVehicle(string i_LicenseNumber, float i_amountOfEnergyToFill, FuelEngine.eFuelType i_FuelType)
        {
            Engine vehicleEngine = AllGarageVehicles[i_LicenseNumber].Vehicle.Engine;

            bool isFuelEngine = vehicleEngine is FuelEngine;

            if (isFuelEngine)
            {
                bool isCorrectTypeOfFuel = i_FuelType == (vehicleEngine as FuelEngine).FuelType;

                if (isCorrectTypeOfFuel)
                {
                    AllGarageVehicles[i_LicenseNumber].Vehicle.FillEnergy(i_amountOfEnergyToFill);
                }
                else
                {
                    throw new ArgumentException("The fuel type is not the same as the vehicle fuel type");
                }
            }
            else
            {
                throw new ArgumentException("This vehicle is not a fuel based vehicle");
            }
        }

        // This function gets License number and amount of minutes to charge and charge this electric based vehicle
        public void ChargeVehicle(string i_LicenseNumber, float i_NumbOfMinutesToAdd)
        {
            Engine vehicleEngine = AllGarageVehicles[i_LicenseNumber].Vehicle.Engine;

            bool isElectricEngine = vehicleEngine is ElectricEngine;

            if (isElectricEngine)
            {
                AllGarageVehicles[i_LicenseNumber].Vehicle.FillEnergy(i_NumbOfMinutesToAdd);
            }
            else
            {
                throw new ArgumentException("This vehicle is not a fuel based vehicle");
            }
        }
    }
}
