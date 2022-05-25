using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }

        // Prperties
        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        // Ctor
        public FuelEngine(float i_CurrentAmountOfFuel, float i_MaxAmountOfFuel, eFuelType i_FuelType)
            : base(i_CurrentAmountOfFuel, i_MaxAmountOfFuel)
        {
            this.r_FuelType = i_FuelType;
        }

        public override string ToString()
        {
            string fuelEngineStr = string.Format(
@"Engine Type: Fuel Engine
Engine Current amount of energy: {0}
Engine Max amount of energy: {1}",
this.CurrentAmountOfEnergy,
this.MaxEnergyAmount);
            return fuelEngineStr;
        }
    }
}
