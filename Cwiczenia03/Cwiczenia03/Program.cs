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

LiquidContainer lc = new LiquidContainer(1100, 6000, 350, 700);
lc.Load(5900);

// Console.WriteLine(lc.ToString());
// lc.Load(3500);
// Console.WriteLine(lc.ToString());