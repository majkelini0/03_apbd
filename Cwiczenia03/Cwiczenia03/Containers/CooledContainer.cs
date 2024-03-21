using Cwiczenia03.Exceptions;
using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Containers;

public class CooledContainer : Container, IHazardNotifier
{
    private PossibleProducts productType;
    private double temperature;
    private static int serialCount = 0;
    private static Dictionary<PossibleProducts, double> table;
    
    public CooledContainer(PossibleProducts product, double temp)
        : base(2000, 26000, "C-", serialCount )
    {
        if (table == null)
        {
            table = new Dictionary<PossibleProducts, double>();
            table.Add(PossibleProducts.Banana,13.3);
            table.Add(PossibleProducts.Chocolate,18.0);
            table.Add(PossibleProducts.Fish,2);
            table.Add(PossibleProducts.Meat,-15);
            table.Add(PossibleProducts.Ice_cream,-18);
            table.Add(PossibleProducts.Frozen_pizza,-30);
            table.Add(PossibleProducts.Cheese,7.2);
            table.Add(PossibleProducts.Sausages,5.0);
            table.Add(PossibleProducts.Butter,20.5);
            table.Add(PossibleProducts.Eggs,19.0);
        }

        double outTemp;
        table.TryGetValue(product, out outTemp);
        if (temp < outTemp)
        {
            throw new LowTempException("Temperatura w kontenerze jest zbyt niska! " +
                                       "Kontener nie zostanie zaladowany");
        }
        else
        {
            productType = product;
            temperature = temp;
            serialCount++;
        }
    }
    public override void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCargoWeight)
            throw new OverFillException("Ladunek przekracza ladownosc kontenera! " + "Kontener " 
                + this.GetType().Name + " " + SerialNumber + " nie zostanie zaladowany");
        else
            base.Load(cargoWeight);  
    }

    public void NotifyHazard(string msg)
    {
        Console.WriteLine(msg);
    }
    public override string ToString()
    {
        return base.ToString() + ", prod[" + productType + "], temp[" + temperature + "stC]";

    }
}