using Containers;

public class Ship
{
    private readonly List<Container> _containers = new();
    public int MaxVelocity { get; }
    public int MaxAmountOfContainers { get; }
    public  int MaxTotalWeight;
    public double CurrentWeight;

    public Ship(int maxVelocity, int maxAmountOfContainers, int maxTotalWeight)
    {
        MaxVelocity = maxVelocity;
        MaxAmountOfContainers = maxAmountOfContainers;
        MaxTotalWeight = maxTotalWeight;
        CurrentWeight = 0;
    }

    public void AddContainer(Container container)
    {
        if (_containers.Count >= MaxAmountOfContainers)
        {
            throw new InvalidOperationException("Too many containers.");
        }
        if (CurrentWeight + container.CurrentLoad > MaxTotalWeight)
        {
            throw new InvalidOperationException("Weight is too big.");
        }

        if (_containers.Exists(containerOnShip => container.SerialNumber == containerOnShip.SerialNumber))
        {
            throw new InvalidOperationException("Container already exists.");
        }
            
        _containers.Add(container);
        CurrentWeight += container.CurrentLoad;
    }

    public void ListLoadedContainers()
    {
        foreach (var container in _containers)
        {
            Console.WriteLine(container.SerialNumber);
        }
    }

    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }

    public void ShipAndCargoInfo()
    {
        Console.WriteLine("****************************");
        Console.WriteLine("Ship Informations:");
        Console.WriteLine($"MaxVelocity: {MaxVelocity}");
        Console.WriteLine($"MaxAmountOfContainers: {MaxAmountOfContainers}");
        Console.WriteLine($"MaxTotalWeight: {MaxTotalWeight}");
        Console.WriteLine($"CurrentWeight: {CurrentWeight}");
        Console.WriteLine("****************************");
        Console.WriteLine("Load Informations:");
        foreach (var container in _containers)
        {
            container.ContainerInfo();
        }
    }
}