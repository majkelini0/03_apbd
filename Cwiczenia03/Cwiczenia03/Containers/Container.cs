using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Containers;

public abstract class Container : IContainer
{
    public double OwnMass { get; set; }
    public double CargoWeight { get; set; }
    public double MaxCargoWeight { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    protected Container(double ownMass, double maxCargoWeight, int height, int depth, string serialPrefix, int serialCount)
    {
        OwnMass = ownMass;
        MaxCargoWeight = maxCargoWeight;
        Height = height;
        Depth = depth;
        SerialNumber = "KON-" + serialPrefix + serialCount;
    }

    public override string ToString()
    {
        return this.GetType().Name +" | " + OwnMass + ", " + MaxCargoWeight + ", " + Height + ", " + Depth + ", " + SerialNumber;
    }

    public virtual void Load(double cargoWeight)
    {
        Console.WriteLine("Ladowanie kontenra w toku ...");
        CargoWeight = cargoWeight;
        Console.WriteLine(this.GetType().Name + " zostal zaladowany");
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }
}