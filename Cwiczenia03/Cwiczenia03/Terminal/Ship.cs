using System.Collections;
using Cwiczenia03.Containers;
using Cwiczenia03.Interfaces;

namespace Cwiczenia03.Terminal;

public class Ship : IContainer, IHazardNotifier, IEnumerable
{
    private double maxSpeed;
    private int maxContainersCount;
    private double maxContainersWeight;
    private List<Container> List { get; set; }
    public string Name { get; }

    public Ship(double maxSpeed, int maxContainersCount, int maxContainersWeight, string name)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainersCount = maxContainersCount;
        this.maxContainersWeight = maxContainersWeight;
        Name = name;
        List = new List<Container>();
    }

    public void LoadContainerOnShip(Container con)
    {
        if (List.Count < maxContainersCount)
        {
            List.Add(con);
            Console.WriteLine(Name + ": zaladowano kontener " + con.GetType().Name + " " + con.SerialNumber);
        }
        else
            NotifyHazard(Name + " osiagnal maksymalna liczbe kontenerow! " +
                         "Kontener nie zostanie zaladowany");
    }

    public void UnloadContainerFromShip(string serNum)
    {
        Container toRemove = null;
        foreach (Container container in List)
        {
            if (container.SerialNumber == serNum)
            {
                toRemove = container;
                break;
            }
        }
        if (toRemove != null)
        {
            List.Remove(toRemove);
            Console.WriteLine(Name + ": usunięto kontener " + toRemove.GetType().Name + " " + serNum);
        }
        else
        {
            Console.WriteLine(Name + ": nie znaleziono kontenera " + toRemove.GetType().Name + " " + serNum);
        }
    }
    public void ReplaceContainerWith(string containerSerialNumber, Container newContainer)
    {
        FindContainerTransferOrReplace(null, containerSerialNumber, newContainer, "replace");
    }
    public void TransferContainerBetweenShips(Ship targetShip, string containerSerialNumber)
    {
        FindContainerTransferOrReplace(targetShip, containerSerialNumber, null, "transfer");
    }

    private void FindContainerTransferOrReplace(Ship targetShip, string containerSerialNumber,Container newContainer , string mode)
    {
        Container containerToTransfer = null;
        
        foreach (Container container in this)
        {
            if (container.SerialNumber == containerSerialNumber)
            {
                containerToTransfer = container;
                break;
            }
        }

        if (containerToTransfer != null)
        {
            if (mode.Equals("replace"))
            {
                UnloadContainerFromShip(containerToTransfer.SerialNumber);
                LoadContainerOnShip(newContainer);
            }

            if (mode.Equals("transfer"))
            {
                UnloadContainerFromShip(containerToTransfer.SerialNumber);
                targetShip.LoadContainerOnShip(containerToTransfer);
            }
        }
        else
            Console.WriteLine(this.Name + ": kontener " + containerSerialNumber + " nie został znaleziony");
    }
    public void LoadedContainers()
    {
        Console.WriteLine(Name + ": załadowane kontenery:");
        foreach (Container container in List)
        {
            Console.WriteLine(container.ToString());
        }
    }
    public void NotifyHazard(string msg)
    {
        Console.WriteLine(msg);
    }
    public IEnumerator GetEnumerator()
    {
        foreach (Container container in List)
        {
            yield return container;
        }
    }

    public void LoadContainerList(List<Container> myList)
    {
        List<string> toBeUnloaded = new List<string>();
        foreach (Container container in List)
        {
            bool found = false;
            foreach (Container con in myList)
            {
                if (container.SerialNumber == con.SerialNumber)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                toBeUnloaded.Add(container.SerialNumber);
            }
        }

        foreach (string str in toBeUnloaded)
        {
            UnloadContainerFromShip(str);
        }

        foreach (Container container in myList)
        {
            bool found = false;
            foreach (Container con in List)
            {
                if (container.SerialNumber == con.SerialNumber)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                LoadContainerOnShip(container);
            }
        }
    }
    public void ShipInfo()
    {
        Console.WriteLine(this);
    }
    public override string ToString()
    {
        return Name + ": speed[" + maxSpeed + "knot], conCount[" + maxContainersCount 
               + "], maxLoad[" + maxContainersWeight + "kg], cap[" + List.Count + "]";
    }
}