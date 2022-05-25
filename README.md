# Garage-Management-System
C# : Developing a computer software that “manages” 5 types of vehicle garage:

1. Fuel-Based Motorcycle:
   2 tires with max air pressure of 31 (psi), Octane 98 (fuel), 6.2 liters fuel tank
2. Electric Motorcycle
   2 tires with max air pressure of 31 (psi), Max battery life – 2.5 hours
3. Fuel-Based Car
   4 tires with max air pressure of 29 (psi), Octane 95 fuel, 38 liter fuel tank
4. Electric Car
   4 tires with max air pressure of 29 (psi), Max battery life – 3.3 hours
5. Fuel-Based Truck
   16 tires with max air pressure of 24 (psi), Soler fuel, 120 liter fuel tank

The program Design and implement s.t the user interface and the logical layer (which manages 
the object model and the logical entities of the system) is Separated. That way adding a new vehicle type
(i.e. Tractor) in the future will be possible without changing any code (except minor additions in the 
class "VehicleCrator" that creates the vehicle objects).

The system can supply the user with the following functions:
1. “Insert” a new vehicle into the garage. The user will be asked to select a
   vehicle type out of the supported vehicle types, and to input the license
   number of the vehicle. If the vehicle is already in the garage (based on
   license number) the system will display an appropriate message and will use
   the vehicle in the garage (and will change the vehicle status to “In Repair”), if
   not, a new object of that vehicle type will be created and the user will be
   prompted to input the values for the properties of his vehicle, according to the
   type of vehicle he wishes to add.
2. Display a list of license numbers currently in the garage, with a filtering option
   based on the status of each vehicle
3. Change a certain vehicle’s status (Prompting the user for the license number and
   new desired status)
4. Inflate tires to maximum (Prompting the user for the license number)
5. Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type
   and amount to fill)
6. Charge an electric-based vehicle (Prompting the user for the license number
   and number of minutes to charge)
7. Display vehicle information (License number, Model name, Owner name, Status in
   garage, Tire specifications (manufacturer and air pressure), Fuel status + Fuel type /
   Battery status, other relevant information based on vehicle type).
   
   Enjoy :)
   
