// See https://aka.ms/new-console-template for more information


using Containers;

var ship = new Ship(50, 8, 2000);
Container container = new LiquidContainer(20, 200, 500, 80, true);
Console.WriteLine(container.CurrentLoad);
Console.WriteLine(container.OwnWeight);
Console.WriteLine(container.MaxLoadCapacity);
Console.WriteLine(container.Depth);
Console.WriteLine(container.Height);
Console.WriteLine(container.SerialNumber);
container.Load(10);
Console.WriteLine(container.CurrentLoad);
container.Unload();
Console.WriteLine(container.CurrentLoad);
container.ContainerInfo();

ship.AddContainer(container);
var container2 = new LiquidContainer(10, 100, 300, 80, true);
var container3 = new LiquidContainer(10, 100, 300, 80, false);
ship.AddContainer(container2);
ship.AddContainer(container3);

var gasContainer = new GasContainer(20, 100, 300, 1000, 200);
Console.WriteLine(gasContainer.Pressure);
gasContainer.Load(10);
Console.WriteLine(gasContainer.CurrentLoad);
gasContainer.Unload();
Console.WriteLine(gasContainer.CurrentLoad);
// gasContainer.Load(1000);

// var coldContainer = new ColdContainer(10, 100, 300, 80, "Dupa", 12);
// var coldContainer = new ColdContainer(10, 100, 300, 80, "Bananas", 12);
var coldContainer = new ColdContainer(10, 100, 300, 80, "Bananas", 14);
Console.WriteLine(coldContainer.Temperature);
Console.WriteLine(coldContainer.ProductType);
// coldContainer.Load(10, "Peaches");

ship.AddContainer(coldContainer);
ship.AddContainer(gasContainer);
ship.ListLoadedContainers();
ship.RemoveContainer(container);
Console.WriteLine("*******");
ship.ListLoadedContainers();
Console.WriteLine(ship.MaxVelocity);

ship.ShipAndCargoInfo();

var ship2 = new Ship(50, 8, 2000);
var crane = new Crane();
crane.MoveContainerFromShipToAnotherShip(container, ship, ship2);
ship2.ListLoadedContainers();