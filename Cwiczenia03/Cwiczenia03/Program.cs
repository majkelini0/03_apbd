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
        lc.ContainerInfo();
        lc.Load(10000);
        lc.ContainerInfo();
// lc.Load(25000); // -> OverFillException
// lc.Load(13000); // (gdy Hazrad = true) -> IHazardNotifier >50%
// lc.Load(22000); // (gdy Hazrad = false) -> IHazardNotifier >90%

        GasContainer gc = new GasContainer();
        gc.Load(100);
        gc.ContainerInfo();
        gc.Load(19500);
        gc.ContainerInfo();
        gc.Unload();
        gc.ContainerInfo();
        gc.Unload();
        gc.ContainerInfo();

        CooledContainer cc = new CooledContainer(PossibleProducts.Banana, 13.3);
// CooledContainer cc = new CooledContainer(PossibleProducts.Banana, 10); // -> LowTempException
        cc.ContainerInfo();
        cc.Load(24000);
        cc.ContainerInfo();
        cc.Unload();
        cc.ContainerInfo();
        
        Console.WriteLine();
        
        Console.WriteLine("Orzel");
        Ship orzel = new Ship(41, 19500, 429000000, "Orzel");
        orzel.LoadContainerOnShip(gc);
        orzel.LoadContainerOnShip(lc);
        orzel.LoadContainerOnShip(cc);

        orzel.UnloadContainerFromShip("KON-L-0");
        orzel.LoadedContainers();

        Console.WriteLine("Marek");
        Ship marek = new Ship(39, 18000, 396000000, "Marek");
        
        Console.WriteLine("Swap kontenerow");
        orzel.TransferContainerBetweenShips(marek, "KON-C-0");
        Console.WriteLine("Swap kontenerow");
        orzel.TransferContainerBetweenShips(marek, "KON-C-2");
        orzel.LoadedContainers();
        marek.ShipInfo();
        marek.LoadedContainers();
        
        Console.WriteLine("ReplaceContainerWith");
        marek.ReplaceContainerWith("KON-C-0", new CooledContainer(PossibleProducts.Chocolate, 20.66));
        marek.LoadedContainers();

        Console.WriteLine("TEST\n");
        List<Container> myList = new List<Container>();
        Ship koko = new Ship(43, 17000, 340000000, "Koko");

        GasContainer gc1 = new GasContainer();
        GasContainer gc2 = new GasContainer();
        koko.LoadContainerOnShip(gc1);
        koko.LoadContainerOnShip(gc2);
        for (int i = 0; i < 5; i++)
        {
            koko.LoadContainerOnShip(new GasContainer());   
        }
        koko.LoadedContainers();
        
        myList.Add(new GasContainer());
        myList.Add(new GasContainer());
        myList.Add(gc1);
        myList.Add(gc2);
        
        koko.LoadContainerList(myList);
        koko.LoadedContainers();
    }
}

