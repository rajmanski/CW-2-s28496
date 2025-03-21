namespace Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    
    public GasContainer(int ownWeight, int height, int depth, int maxLoadCapacity, double pressure)
        : base(ownWeight, height, depth, maxLoadCapacity, "G")
    {
        Pressure = pressure;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT]: {message} {SerialNumber}");
    }

    public override void Unload()
    {
        CurrentLoad = CurrentLoad * 0.05;
    }
}