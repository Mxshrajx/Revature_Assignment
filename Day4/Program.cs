using System;
using System.Collections.Generic;
interface IMaintainable
{
    void ScheduleMaintenance();
}
interface ITrackable
{
    string GetLocation();
}
abstract class Vehicle
{
    private double fuelLevel;

    public int Id { get; }
    public string Make { get; set; }
    public string Model { get; set; }

    public double FuelLevel
    {
        get => fuelLevel;
        set => fuelLevel = value < 0 ? 0 : value;
    }

    private static int nextId = 1;

    protected Vehicle(string make, string model, double fuel = 100)
    {
        Id = nextId++;
        Make = make;
        Model = model;
        FuelLevel = fuel;
    }

    public abstract void Start();
    public void Stop() => Console.WriteLine($"{Make} {Model} stopped.");
}
class Car : Vehicle, IMaintainable, ITrackable
{
    public Car(string make, string model, double fuel = 100) : base(make, model, fuel) { }

    public override void Start() => Console.WriteLine($"{Make} {Model} car started.");
    public void ScheduleMaintenance() => Console.WriteLine($"{Make} {Model} car maintenance scheduled.");
    public string GetLocation() => $"{Make} {Model} car location: (X,Y)";
}
class Truck : Vehicle, IMaintainable, ITrackable
{
    public Truck(string make, string model, double fuel = 100) : base(make, model, fuel) { }

    public override void Start() => Console.WriteLine($"{Make} {Model} truck roaring to life!");
    public void ScheduleMaintenance() => Console.WriteLine($"{Make} {Model} truck maintenance scheduled.");
    public string GetLocation() => $"{Make} {Model} truck location: (X,Y)";
}

class Program
{
    static void Main()
    {
        var fleet = new List<Vehicle>
        {
            new Car("Toyota", "Camry"),
            new Truck("Volvo", "FH16"),
            new Car("Honda", "Civic")
        };

        Console.WriteLine("=== Start Fleet ===");
        foreach (var v in fleet) v.Start();

        Console.WriteLine("\n=== Stop Fleet ===");
        foreach (var v in fleet) v.Stop();

        Console.WriteLine("\n=== Maintenance ===");
        foreach (var v in fleet)
        {
            if (v is IMaintainable m) m.ScheduleMaintenance();
        }

        Console.WriteLine("\n=== Tracking ===");
        foreach (var v in fleet)
        {
            if (v is ITrackable t) Console.WriteLine(t.GetLocation());
        }
        Console.WriteLine("\n=== Fuel Levels ===");
        foreach (var v in fleet)
        {
            Console.WriteLine($"{v.Make} {v.Model} fuel: {v.FuelLevel}");
            v.FuelLevel -= 50;
            Console.WriteLine($"After driving: {v.FuelLevel}");
        }
    }
}