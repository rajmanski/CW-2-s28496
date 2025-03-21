namespace Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(int ownWeight, int height, int depth, int maxLoadCapacity, bool isHazardous)
        : base(ownWeight, height, depth, maxLoadCapacity, "L")
    {
        IsHazardous = isHazardous;
    }

    public override void Load(int weight)
    {
        int maxAllowedLoad = IsHazardous ? MaxLoadCapacity / 2 : (int)(MaxLoadCapacity * 0.9);
        if (CurrentLoad + weight > maxAllowedLoad)
        {
            NotifyHazard($"Próba przeładowania kontenera {SerialNumber} - maksymalna dopuszczalna ładowność została przekroczona!");
            throw new OverfillException($"Przekroczono dopuszczalny poziom ładunku w kontenerze {SerialNumber}!");
        }
        base.Load(weight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[ALERT]: {message}");
    }
}
