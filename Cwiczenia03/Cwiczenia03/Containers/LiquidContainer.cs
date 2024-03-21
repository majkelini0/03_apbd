using Cwiczenia03.Exceptions;
using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool hazardMaterialInside;
    private static int serialCount = 0;
    public LiquidContainer() 
        : base(2500, 24000, "L-", serialCount )
    {
        hazardMaterialInside = false;
        serialCount++;
    }

    public override void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight)
            throw new OverFillException("Ladunek przekracza ladownosc kontenera! " +
                                        "Kontener " + this.GetType().Name + " " + SerialNumber + " nie zostanie zaladowany");
        
        Console.WriteLine("Czy kontener przewozi niebezpieczny ladunek? [y]es / [n]o ? ");
        if (Console.ReadLine().ToLower().Equals("y"))
        {
            hazardMaterialInside = true;
            if (MaxCargoWeight * 0.5 <= cargoWeight)
                NotifyHazard("Masa krytyczyna kontenera dla substacji niebezpiecznej zostala przekroczona\n" +
                             "Kontener nie zostanie zaladowany");
            else
                base.Load(cargoWeight);   
        }
        else
        {
            if (MaxCargoWeight * 0.9 <= cargoWeight)
            {
                NotifyHazard("Masa krytyczna 90% zostala osiagnieta\n" +
                             "Kontener nie zostanie zaladowany");
            }
            else
                base.Load(cargoWeight);
        }
    }
    public override void Unload()
    {
        base.Unload();
        hazardMaterialInside = false;
    }

    public void NotifyHazard(string msg)
    {
        Console.WriteLine(msg);
    }

    public override string ToString()
    {
        return base.ToString() + ", hazard[" + hazardMaterialInside + "]";

    }
}