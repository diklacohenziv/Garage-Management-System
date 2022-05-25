using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GarageVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_CustomerName;
        private readonly string r_CustomerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public enum eVehicleStatus
        {
            inRepair,
            Repaired,
            Payed,
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public string CustomerName
        {
            get { return r_CustomerName; }
        }

        public string CustomerPhoneNumber
        {
            get { return r_CustomerPhoneNumber; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        // Ctor
        public GarageVehicle(string i_CustomerName, string i_CustomerPhoneNumber, Vehicle i_CustomerVehicle)
        {
            r_CustomerName = i_CustomerName;
            r_CustomerPhoneNumber = i_CustomerPhoneNumber;
            r_Vehicle = i_CustomerVehicle;
            m_VehicleStatus = eVehicleStatus.inRepair;
        }

        public override string ToString()
        {
            StringBuilder garageVehicleStr = new StringBuilder();
            string garageVehicleInfos = string.Format(
@"Owner Name: {0}
Owner Phone Number: {1}
Vehicle Status: {2}",
this.CustomerName,
this.CustomerPhoneNumber,
this.VehicleStatus);

            garageVehicleStr.AppendLine(garageVehicleInfos);
            garageVehicleStr.AppendLine(this.Vehicle.ToString());
            return garageVehicleStr.ToString();
        }
    }
}
