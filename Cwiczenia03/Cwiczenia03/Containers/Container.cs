using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Containers;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }
    protected Container(double cargoWeight)
    {
        CargoWeight = cargoWeight;
    }
    public virtual void Load(double cargoWeight)
    {
        if (cargoWeight > 1000)
        {
            throw new OverflowException();
        }
        throw new NotImplementedException();
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }
}