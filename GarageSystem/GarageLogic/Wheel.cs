using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;

        // Properties
        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }

            set
            {
                if (value < 0 || value > MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, MaxAirPressure);
                }

                this.m_CurrentAirPressure = value;
            }
        }

        // Ctor
        public Wheel(string i_WheelManufacturerName, float i_CurrentAmountOfAirPressur, float i_MaxAmuntOfAirPressuer)
        {
            this.r_ManufacturerName = i_WheelManufacturerName;
            this.r_MaxAirPressure = i_MaxAmuntOfAirPressuer;
            this.CurrentAirPressure = i_CurrentAmountOfAirPressur;
        }

        // This function inflate the tire without crossing the max amount possible for this tire
        public void InflateOneTire(float i_AirAmountToAdd)
        {
            if (CurrentAirPressure + i_AirAmountToAdd > MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure);
            }
            else
            {
                CurrentAirPressure += i_AirAmountToAdd;
            }
        }

        public override string ToString()
        {
            string wheelDataStr = string.Format(
@"Wheel Manufucturer: {0}
Wheel Air Pressure: {1}
Wheel Max Air Pressure: {2}",
this.ManufacturerName,
this.CurrentAirPressure,
this.MaxAirPressure);

            return wheelDataStr;
        }
    }
}
