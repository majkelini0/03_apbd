// See https://aka.ms/new-console-template for more information

using System.ComponentModel;using System.Security.Cryptography;
using Cwiczenia03;
using Cwiczenia03.Containers;
using Cwiczenia03.Terminal;
using Cwiczenia03.Terminal;
using Container = Cwiczenia03.Containers.Container;

class Program
{
    static void Main()
    {
        LiquidContainer lc = new LiquidContainer();
        Console.WriteLine(lc);
        lc.Load(10000);
        Console.WriteLine(lc);
// lc.Load(25000); // -> OverFillException
// lc.Load(13000); // (gdy Hazrad = true) -> IHazardNotifier >50%
// lc.Load(22000); // (gdy Hazrad = false) -> IHazardNotifier >90%

        GasContainer gc = new GasContainer();
        gc.Load(100);
        Console.WriteLine(gc);
        gc.Load(19500);
        Console.WriteLine(gc);
        gc.Unload();
        Console.WriteLine(gc);
        gc.Unload();
        Console.WriteLine(gc);

        CooledContainer cc = new CooledContainer(PossibleProducts.Banana, 13.3);
// CooledContainer cc = new CooledContainer(PossibleProducts.Banana, 10); // -> LowTempException
        Console.WriteLine(cc);
        cc.Load(24000);
        Console.WriteLine(cc);
        cc.Unload();
        Console.WriteLine(cc);

        Ship orzel = new Ship(41, 19500, 429000000);
        orzel.loadContainerOnShip(gc);
        orzel.loadContainerOnShip(lc);
        orzel.loadContainerOnShip(cc);
//Console.WriteLine(orzel.List);
        orzel.unloadContainerFromShip("KON-L-0");
        orzel.DisplayLoadedContainers();

        Ship marek = new Ship(39, 18000, 396000000);
        ShipInfo(marek);
        ContainerInfo(lc);
        
        //TransferContainerBetweenShips(orzel, marek, "KON-C-0");
        marek.DisplayLoadedContainers();
        
        
    }
    static void ContainerInfo(Cwiczenia03.Containers.Container c)
    {
        Console.WriteLine(c);
    }

    static void ShipInfo(Ship s)
    {
        Console.WriteLine(s);
    }
    public static void TransferContainerBetweenShips(Ship sourceShip, Ship targetShip, string containerSerialNumber)
    {
        Container containerToTransfer = null;
        foreach (Container container in sourceShip.List)
        {
            if (container.ReturnSerial() == containerSerialNumber)
            {
                containerToTransfer = container;
                break;
            }
        }

        if (containerToTransfer != null)
        {
            sourceShip.List.Remove(containerToTransfer);
            Console.WriteLine("Kontener o numerze seryjnym" + containerSerialNumber + " został usunięty ze statku źródłowego");
            
            targetShip.loadContainerOnShip(containerToTransfer);
            Console.WriteLine("Kontener o numerze seryjnym " + containerSerialNumber + " został dodany do statku docelowego");
        }
        else
        {
            Console.WriteLine("Kontener o numerze seryjnym " + containerSerialNumber + " nie został znaleziony na statku źródłowym");
        }
    }
}

