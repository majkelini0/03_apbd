using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Containers;

public abstract class Container : IContainer
{
    protected double OwnMass { get; }
    protected double CargoWeight { get; set; }
    protected double MaxCargoWeight { get; }
    protected double Height { get; }
    protected double Width { get; }
    protected double Depth { get; }
    //private string serialNumber; // field
    public string SerialNumber { get; } // property
    protected Container(double ownMass, double maxCargoWeight, string serialPrefix, int serialCount)
    {
        CargoWeight = 0;
        OwnMass = ownMass;
        MaxCargoWeight = maxCargoWeight;
        Height = 260;
        Width = 230;
        Depth = 1200;
        SerialNumber = "KON-" + serialPrefix + serialCount;
    }

    public virtual void Load(double cargoWeight)
    {
        Console.WriteLine("Ladowanie kontenra w toku ...");
        CargoWeight = cargoWeight;
        Console.WriteLine(this.GetType().Name + " " + this.SerialNumber + " zostal zaladowany");
    }

    public virtual void Unload()
    {
        Console.WriteLine("Rozladunek kontenra w toku ...");
        CargoWeight = 0;
        Console.WriteLine(this.GetType().Name + " " + this.SerialNumber + " zostal rozladowany");
    }

    public void ContainerInfo()
    {
        Console.WriteLine(this);
    }
    public override string ToString()
    {
        return this.GetType().Name + " ser[" + SerialNumber + "], ownMass[" + OwnMass + "kg], maxCargo[" + MaxCargoWeight + "kg], cargo[" +
               CargoWeight + "kg], height[" + Height + "cm], width[" + Width + "cm], depth[" + Depth + "cm]";
    }
}