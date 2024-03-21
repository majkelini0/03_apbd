using Cwiczenia03.Exceptions;
using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Containers;

public class GasContainer : Container, IHazardNotifier
{
    private double pressure;
    private static int serialCount = 0;
    
    public GasContainer() 
        : base(2700, 22000, "G-", serialCount )
    {
        pressure = 0;
        serialCount++;
    }

    public override void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight)
            throw new OverFillException("Ladunek przekracza ladownosc kontenera! " + "Kontener " 
                + this.GetType().Name + " " + SerialNumber + " nie zostanie zaladowany");
        if (cargoWeight >= 0.05 * MaxCargoWeight)
        {
            base.Load(cargoWeight);
            pressure = 95 * cargoWeight / MaxCargoWeight;
        }
        else
            NotifyHazard("Minimalna masa ladunku to 5% ladownosci! Kontener nie zostanie zaladowany");
        
    }
    public new void Unload()
    {
        if(CargoWeight <= 0.05 * MaxCargoWeight)
            NotifyHazard("Minimalna masa ladunku nie jest spelniona! Kontener nie moze zostac bardziej rozladowany");
        else
        {
            Console.WriteLine("Rozladunek kontenra w toku ...");
            double toUnload = CargoWeight - 0.05 * MaxCargoWeight;
            CargoWeight -= toUnload;
            pressure = 95 * CargoWeight / MaxCargoWeight;   
            Console.WriteLine(this.GetType().Name + " " + this.SerialNumber + " zostal rozladowany");
        }
    }
    public void NotifyHazard(string msg)
    {
        Console.WriteLine(msg);
    }
    public override string ToString()
    {
        return base.ToString() + ", bar[" + pressure + "]";

    }
}