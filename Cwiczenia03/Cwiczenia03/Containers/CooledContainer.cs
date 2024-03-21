namespace Cwiczenia03.Containers;

public class CooledContainer : Container
{
    private PossibleProducts productType;
    private double temperature;
    private static int serialCount = 0;
    private static Dictionary<PossibleProducts, double> table;
    
    public CooledContainer(PossibleProducts product, double temp)
        : base(2000, 26000, "C-", serialCount )
    {
        productType = product;
        temperature = temp;
        serialCount++;
    }
}