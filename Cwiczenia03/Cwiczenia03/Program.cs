// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using Cwiczenia03;
using Cwiczenia03.Containers;

// using Cwiczenia03.Containers;
//var container = new Container() { CargoWeight = 100.0 };
// var list = new List<int>() { 1, 2, 3 };
// Dictionary<string, int> dict = new Dictionary<string, int>();
// Dictionary<PossibleProducts, double> products;
// int? x;
// x = null;

LiquidContainer lc = new LiquidContainer();
//lc.Load(30000);
//lc.Load(23000);
//lc.Load(10000);
//lc.Unload();
//Console.WriteLine(lc.ToString());

GasContainer gc = new GasContainer();
gc.Load(21000);
Console.WriteLine(gc.ToString());
gc.Unload();
Console.WriteLine(gc.ToString());
gc.Unload();
Console.WriteLine(gc.ToString());

CooledContainer cc = new CooledContainer(PossibleProducts.Bananas, 22.3);

//Console.WriteLine(lc.ToString());