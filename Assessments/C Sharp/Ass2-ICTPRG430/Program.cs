// Sasha Andersen
// Created 13/07/2022
// Vehicle is the base class with Car class and Vehicle class inheriting from it. There is one overriding method from Vehicle to the subclasses.
// Driver class is aggregated into the Vehicle class.
// Program class creates objects and calls all methods.

using System;
using System.IO;
using System.Text;

namespace Ass2_ICTPRG430
{
  public class Vehicle
  {
    string regNo;
    string make;
    string model;
    public int kmDriven;
    public Driver driver;
    public Vehicle(string regNo, string make, string model, int kmDriven, Driver driver)
    {
      this.regNo = regNo;
      this.make = make;
      this.model = model;
      this.kmDriven = kmDriven;
      this.driver = driver;
    }
    public virtual void Display()
    {
      Console.WriteLine("Registration number: {0}\nMake: {1}\nModel: {2}\nKM driven: {3}", this.regNo, this.make, this.model, this.kmDriven);
    }
    public void KmUpdate(int kmAmend)
    {
      if (kmDriven + kmAmend >= 0)
      {
        kmDriven += kmAmend;
        Console.WriteLine("KM updated to: " + kmDriven);
      }
      else
      {
        Console.WriteLine("Error: KM unable to go below zero");
        Console.WriteLine("KM has remained at: " + kmDriven);
      }
    }
  }
  class Car : Vehicle
  {
    string bodyType;
    public string colour;
    string upholstery;
    int doorNo;
    public Car(string regNo, string make, string model, int kmDriven, Driver driver, string bodyType, string colour, string upholstery, int doorNo) : base(regNo, make, model, kmDriven, driver)
    {
      this.bodyType = bodyType;
      this.colour = colour;
      this.upholstery = upholstery;
      this.doorNo = doorNo;
    }
    public void DisplaySpecCar()
    {
      Console.WriteLine("Body type: {0}\nColour: {1}\nUpholstery: {2}\nNumber of doors: {3}", this.bodyType, this.colour, this.upholstery, this.doorNo);
    }
    public void DisplayGenCar()
    {
      base.Display();
    }
    public override void Display()
    {
      DisplaySpecCar();
      base.Display();
    }
    public void DisplayAllCar()
    {
      Display();
      driver.DisplayDriver();
    }
    public void ColourCar(string newColour)
    {
      colour = newColour;
      Console.WriteLine("Car colour updated to: " + colour);
    }
  }
  class Truck : Vehicle
  {
    int maxLoad;
    int axlesNo;
    int wheelsNo;
    public Truck(string regNo, string make, string model, int kmDriven, Driver driver, int maxLoad, int axlesNo, int wheelsNo) : base(regNo, make, model, kmDriven, driver)
    {
      this.maxLoad = maxLoad;
      this.axlesNo = axlesNo;
      this.wheelsNo = wheelsNo;
      this.driver = driver;
    }
    public void DisplaySpecTruck()
    {
      Console.WriteLine("Max load: {0}\nNumber of axles: {1}\nNumber of wheels: {2}", this.maxLoad, this.axlesNo, this.wheelsNo);
    }
    public void DisplayGenTruck()
    {
      base.Display();
    }
    public override void Display()
    {
      DisplaySpecTruck();
      base.Display();
    }
    public void DisplayAllTruck()
    {
      Display();
      driver.DisplayDriver();
    }
  }

  public class Driver
  {
    int licenceNo;
    string firstName;
    string lastName;
    int mobileNo;
    string[] address;
    string[] licenceState;
    public int demeritPoints = 0;
    static int DemeritMax = 12;
    public Driver (string firstName, string lastName, int licenceNo, int mobileNo, string[] address, string[] licenceState, int demeritPoints)
    {
      this.firstName = firstName;
      this.lastName = lastName;
      this.licenceNo = licenceNo;
      this.mobileNo = mobileNo;
      this.address = address;
      this.licenceState = licenceState;
      this.demeritPoints = demeritPoints;
    }
    public void DisplayDriver()
    {
      Console.WriteLine("The driver {0} {1}, has a driver licence number: {2}\nContact phone number is: {3}", this.firstName, this.lastName, this.licenceNo, this.mobileNo);
      for (int i = 0; i < address.Length; i++)
      {
        Console.WriteLine(address[i]);
      }
      Console.Write("The driver is licenced to drive in the following states");
      for (int i = 0; i < licenceState.Length; i++)
      {
        Console.Write(" : " + licenceState[i]);
      }
      Console.WriteLine("\nCurrent demerit points are: " + demeritPoints);
    }
    public void WriteFile(string location)
    {
      File.AppendAllText(location, "\n" + firstName + " " + lastName + "\n" + licenceNo + "\n" + mobileNo + "\n" + demeritPoints + "\n");
      File.AppendAllLines(location, licenceState);
      File.AppendAllLines(location, address);
      
    }
    public void ReadFile(string location)
    {
      string readText = File.ReadAllText(location);
      Console.WriteLine(readText);
    }
    public void DemeritUpdate(int demeritUpdate)
    {
      if (demeritPoints + demeritUpdate < 0)
      {
        Console.WriteLine("Error: Demerit points cannot go below zero.");
        Console.WriteLine("Demerit points have remained at: " + demeritPoints);
      }
      else if (demeritPoints + demeritUpdate >= 0 && demeritPoints + demeritUpdate < 9)
      {
        demeritPoints += demeritUpdate;
        Console.WriteLine("Demerit points have been updated to: " + demeritPoints);
      }
      else if (demeritPoints + demeritUpdate >= 9 && demeritPoints + demeritUpdate < DemeritMax)
      {
        demeritPoints += demeritUpdate;
        Console.WriteLine("Demerit points have been updated to: " + demeritPoints);
        Console.WriteLine("Warning: License suspension is imminent.");
      }
      else if (demeritPoints + demeritUpdate == DemeritMax)
      {
        demeritPoints += demeritUpdate;
        Console.WriteLine("Demerit points have been updated to: " + demeritPoints);
        Console.WriteLine("Warning: License has been suspended due to demerit points at 12 points.");
      }
      else if (demeritPoints + demeritUpdate > DemeritMax)
      {
        Console.WriteLine("Error: Demerit points cannot go above 12.");
        Console.WriteLine("Demerit points have remained at: " + demeritPoints);
      }
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      // Instantiation of objects
      string location = @"C:\Temp\TruckingAustralia.txt"; 
      string[] address1 = { "Street: 99 Red Balloons", "City: Sydney", "State: NSW", "Postcode: 2000" };
      string[] licenceState1 = { "Victoria", "Queensland"};
      string[] address2 = { "Street: 007 Bond Street", "City: Melbourne", "State: VIC", "Postcode: 3000" };
      string[] licenceState2 = { "Victoria", "New South Wales", "Queensland"};
      Driver driver1 = new Driver("Minnie", "Mouse", 1112223333, 1234123123, address1, licenceState1, 5);
      Driver driver2 = new Driver("Bugs", "Bunny", 333222111, 1321321321, address2, licenceState2, 6);
      Car car1 = new Car("YC7 AWH", "BMW", "i4", 8000, driver1, "Sedan", "Black", "Synthetic leather", 4);
      Car car2 = new Car("LF7 AUK", "Tesla", "Model Y", 8500, driver2, "Sedan", "Silver", "Leather", 4);
      Truck truck1 = new Truck("123 abc", "Volvo", "Zoomie", 12000, driver1, 9000, 5, 18);
      Truck truck2 = new Truck("abc 123", "Freightliner", "Big boss", 12500, driver2, 9500, 6, 18);

      // CARS
      // Display specific details, general details and then both together for each car
      Console.WriteLine("\nCar 1: Specific details..."); 
      car1.DisplaySpecCar();
      Console.WriteLine("\nCar 1: General details...");
      car1.DisplayGenCar();
      Console.WriteLine("\nCar 1: Specific AND general details...");
      car1.Display();

      Console.WriteLine("\nCar 2: Specific details...");
      car2.DisplaySpecCar();
      Console.WriteLine("\nCar 2: General details...");
      car2.DisplayGenCar();
      Console.WriteLine("\nCar 2: Specific AND general details...");
      car2.Display();

      // Editing km
      Console.WriteLine("\nAdding 2000km to car 2...");
      Console.WriteLine("Current km: " + car2.kmDriven);
      car2.KmUpdate(2000);

      Console.WriteLine("\nAttempting to go below zero and minus 11000km to car 2...");
      Console.WriteLine("Current km: " + car2.kmDriven); 
      car2.KmUpdate(-11000);

      // Changing colour of the car
      Console.WriteLine("\nColouring car 2 to red...");
      Console.WriteLine("Current colour: " + car2.colour);
      car2.ColourCar("Red");

      // TRUCKS
      // Display specific details, general details and then both together for each truck
      Console.WriteLine("\nTruck 1: Specific details..."); 
      truck1.DisplaySpecTruck();
      Console.WriteLine("\nTruck 1: General details...");
      truck1.DisplayGenTruck();
      Console.WriteLine("\nTruck 1: Specific AND general details...");
      truck1.Display();

      Console.WriteLine("\nTruck 2: Specific details...");
      truck2.DisplaySpecTruck();
      Console.WriteLine("\nTruck 2: General details...");
      truck2.DisplayGenTruck();
      Console.WriteLine("\nTruck 2: Specific AND general details...");
      truck2.Display();

      // Editing km
      Console.WriteLine("\nAdding 2000km to truck 2...");
      Console.WriteLine("Current km: " + truck2.kmDriven);
      truck2.KmUpdate(2000);

      Console.WriteLine("\nAttempting to go below zero and minus 15000km to truck 2...");
      Console.WriteLine("Current km: " + truck2.kmDriven);
      truck2.KmUpdate(-15000);

      // DRIVERS
      // Display driver details
      Console.WriteLine("\nDisplaying driver 1..."); 
      driver1.DisplayDriver();
      Console.WriteLine("\nDisplaying driver 2...");
      driver2.DisplayDriver();

      // Editing demerit points
      Console.WriteLine("\nAdding 2 demerit points to driver 2...");
      Console.WriteLine("Current driver 2 demerit points: " + driver2.demeritPoints);
      driver2.DemeritUpdate(+2);

      Console.WriteLine("\nAttempting to get warning message by adding another 2 demerit points to driver 2...");
      Console.WriteLine("Current driver 2 demerit points: " + driver2.demeritPoints);
      driver2.DemeritUpdate(+2);

      Console.WriteLine("\nAttempting to get licence suspended by adding another 2 demerit points to driver 2...");
      Console.WriteLine("Current driver 2 demerit points: " + driver2.demeritPoints);
      driver2.DemeritUpdate(+2);

      Console.WriteLine("\nAttempting to go over 12 points by adding 1 demerit point to driver 2...");
      Console.WriteLine("Current driver 2 demerit points: " + driver2.demeritPoints);
      driver2.DemeritUpdate(+1);

      Console.WriteLine("\nAttempting to go below 0 points, minus 6 demerit points to driver 1...");
      Console.WriteLine("Current driver 1 demerit points: " + driver1.demeritPoints);
      driver1.DemeritUpdate(-6);

      // Writing and reading file
      Console.WriteLine("\nWriting and reading driver 2 to file...");
      driver2.WriteFile(location);
      driver2.ReadFile(location);

      // Display specific details, general details and associated driver of each vehicle
      Console.WriteLine("\nCar 1: Specific, general and driver details...");
      car1.DisplayAllCar();
      Console.WriteLine("\nCar 2: Specific, general and driver details...");
      car2.DisplayAllCar();
      Console.WriteLine("\nTruck 1: Specific, general and driver details...");
      truck1.DisplayAllTruck();
      Console.WriteLine("\nTruck 2: Specific, general and driver details...");
      truck2.DisplayAllTruck();
    }
  }
}
