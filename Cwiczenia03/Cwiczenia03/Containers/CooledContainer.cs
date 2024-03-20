namespace Cwiczenia03.Containers;

public class CooledContainer : Container
{
    private string typProduktu;
    private bool temperature;
    
    private static string serialPrefix = "C-";
    private static int serialCount = 0;
    
    public CooledContainer(double ownMass, double maxCargoWeight, int height, int depth) 
        : base(ownMass, maxCargoWeight, height, depth, serialPrefix, serialCount )
    {
        serialCount++;
    }
}