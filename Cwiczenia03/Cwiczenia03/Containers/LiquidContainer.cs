using Cwiczenia03.Exceptions;
using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool hazardMaterialInside { get; set; }
    private static string serialPrefix = "L-";
    private static int serialCount = 0;
    public LiquidContainer(double ownMass, double maxCargoWeight, int height, int depth) 
        : base(ownMass, maxCargoWeight, height, depth, serialPrefix, serialCount )
    {
        hazardMaterialInside = false;
        serialCount++;
    }

    public override void Load(double cargoWeight)
    {
        Console.WriteLine("Czy kontener przewozi niebezpieczny ladunek? [y]es / [n]o ? ");
        if (Console.ReadLine().ToLower().Equals("y"))
            hazardMaterialInside = true;

        if (this.hazardMaterialInside)
        {
            if (this.MaxCargoWeight * 0.5 <= cargoWeight)
                NotifyHazard("Masa krytyczyna kontenera dla substacji niebezpiecznej zostala przekroczona\n" +
                             "Kontener nie zostanie zaladowany");
            else
                base.Load(cargoWeight);
        }

        if (this.MaxCargoWeight * 0.9 <= cargoWeight)
        {
            NotifyHazard("Masa krytyczna 90% zostala osiagnieta\n" +
                         "Kontener nie zostanie zaladowany");
        }
        else
            base.Load(cargoWeight);
    }

    public void NotifyHazard(string msg)
    {
        Console.WriteLine(msg);
        throw new OverFillException(this.SerialNumber);
    }
}