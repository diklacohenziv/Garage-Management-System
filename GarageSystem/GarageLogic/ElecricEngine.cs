using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricEngine : Engine
    {
        // ctor
        public ElectricEngine(float i_CurrentAmountOfMinutes, float i_MaxAmountOfMinutes)
            : base(i_CurrentAmountOfMinutes, i_MaxAmountOfMinutes)
        {
        }

        public override string ToString()
        {
            string electricEngineStr = string.Format(
@"Engine Type: Electric Engine
Engine Current amount of energy: {0}
Engine Max amount of energy: {1}",
this.CurrentAmountOfEnergy,
this.MaxEnergyAmount);
            return electricEngineStr;
        }
    }
}
