namespace Cwiczenia03.Containers;

public class GasContainer : Container
{
    private double pressure;
    private static string serialPrefix = "G-";
    private static int serialCount = 0;
    
    public GasContainer(double ownMass, double maxCargoWeight, int height, int depth) 
        : base(ownMass, maxCargoWeight, height, depth, serialPrefix, serialCount )
    {
        serialCount++;
    }
}