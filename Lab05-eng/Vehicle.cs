using System;
using Vehicles;

namespace Vehicles
{
    abstract class Vehicle

    {
        public static int uID;
        protected readonly int _uID;

        protected Vehicle()
        {
            ++uID;
            _uID = uID;            
        }
        public virtual void Travel(double distance)
        {
        }



    }



    class Car : Vehicle
    {
        //public new static int uID;
       // private new readonly int _uID;
        public string Name;

        public Car(string name)
        {
            
          //  ++uID;
           // _uID = uID;
            Console.WriteLine($"Car ({_uID}) {Name} has been created");

        }

        
        
        public override void Travel(double distance)
        {
            Console.WriteLine($"Car  {Name} traveled {distance}");  
        }
    }
    class Bus : Vehicle
    {
      //  public new static int uID;
        //private new readonly int _uID;
        public string Name;
        public static int passengerLimit = 42;
        public uint PassengerCounts;
        

        public Bus(string name)
        {
            //++uID;
            //_uID = uID;
            Name = name;
            Console.WriteLine($"Bus ({_uID}) {Name} [0/{passengerLimit}] has been created" );
        }
        public override void Travel(double distance)
        {
            Console.WriteLine($"Bus  {Name} traveled {distance} km with {PassengerCounts} passengers");
        }
        public bool SetPassengerCount(uint passenger)
        {
            PassengerCounts = passenger;
            return passenger > 42;
        }

        public uint PassengerCount()
        { return PassengerCounts; }
    }

    class Truck : Vehicle
    {
       // public new static int uID;
       // private new readonly int _uID;
        public string Name;
        public double Weight;
        public static double capacity = 2500;

        public Truck(string name)
        {
          //  ++uID;
           // _uID = uID;
            Name = name;
            Console.WriteLine($"Truck ({_uID}) {Name} [0/{capacity}] has been created.");
        }
        public override void Travel(double distance)
        {
            Console.WriteLine($"Truck  {Name} traveled {distance} km with load of {Weight} kg." );
        }

        public bool SetLoad(double load)
        {
            Weight = load;
            return load > 2500;
        }
        public double Load()
        { return Weight; }


    }
}



