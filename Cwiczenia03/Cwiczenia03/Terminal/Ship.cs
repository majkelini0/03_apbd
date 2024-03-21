using Cwiczenia03.Containers;
using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Terminal;

public class Ship : IContainer, IHazardNotifier
{
    private double maxSpeed;
    private int maxContainersCount;
    private double maxContainersWeight;
    private List<Container> list;
    public List<Container> List { get; }

    public Ship(double maxSpeed, int maxContainersCount, int maxContainersWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainersCount = maxContainersCount;
        this.maxContainersWeight = maxContainersWeight;
        list = new List<Container>();
    }

    public void loadContainerOnShip(Container con)
    {
        if (list.Count < maxContainersCount)
        {
            list.Add(con);
            Console.WriteLine("Statek: zaladowano kontener " + con.GetType().Name + con.ReturnSerial());
        }
        else
            NotifyHazard("Statek osiagnal maksymalna liczbe kontenerow! " +
                         "Kontener nie zostanie zaladowany");
    }

    public void unloadContainerFromShip(string serNum)
    {
        Container toRemove = null;
        foreach (Container container in list)
        {
            if (container.ReturnSerial() == serNum)
            {
                toRemove = container;
                break;
            }
        }
        if (toRemove != null)
        {
            list.Remove(toRemove);
            Console.WriteLine("Usunięto kontener: " + serNum);
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontenera o numerze seryjnym: " + serNum);
        }
    }
    public void DisplayLoadedContainers()
    {
        Console.WriteLine("Załadowane kontenery na statku:");
        foreach (Container container in list)
        {
            Console.WriteLine(container.ToString());
        }
    }

    public void NotifyHazard(string msg)
    {
        Console.WriteLine(msg);
    }

    public override string ToString()
    {
        return "Statek: speed[" + maxSpeed + "knot], conCount[" + maxContainersCount 
               + "], maxLoad[" + maxContainersWeight + "kg]";
    }
    
}