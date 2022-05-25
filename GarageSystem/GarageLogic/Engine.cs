using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergyAmount;
        protected float m_CurrentAmountOfEnergy;

        internal enum eEngineType
        {
            Fuel,
            Electric,
        }

        // Properties
        public float CurrentAmountOfEnergy
        {
            get { return m_CurrentAmountOfEnergy; }

            set
            {
                if (value < 0 || value > MaxEnergyAmount)
                {
                    throw new ValueOutOfRangeException(0, MaxEnergyAmount);
                }

                this.m_CurrentAmountOfEnergy = value;
            }
        }

        public float MaxEnergyAmount
        {
            get { return r_MaxEnergyAmount; }
        }

        // Ctor
        protected Engine(float i_CurrentEnergy, float i_MaxEnergyCapacity)
        {
            this.r_MaxEnergyAmount = i_MaxEnergyCapacity;
            this.CurrentAmountOfEnergy = i_CurrentEnergy;
        }

        public void FillEngineEnergy(float i_AmountOfEnergyToFill)
        {
            if (this.CurrentAmountOfEnergy + i_AmountOfEnergyToFill > MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException(0, MaxEnergyAmount);
            }

            this.CurrentAmountOfEnergy += i_AmountOfEnergyToFill;
        }

        public abstract override string ToString();
    }
}
