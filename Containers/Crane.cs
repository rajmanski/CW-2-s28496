namespace Containers;

public class Crane
{
    public void MoveContainerFromShipToAnotherShip(Container container, Ship ship1, Ship ship2)
    {
        Console.WriteLine("Crane starts to move container...");
        ship1.RemoveContainer(container);
        Console.WriteLine("Container removed from the first ship");
        ship2.AddContainer(container);
        Console.WriteLine("Container was successfully moved to another ship");
    }
}