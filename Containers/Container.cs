using System;

namespace Containers
{
    public abstract class Container
    {
        private static int _counter = new Random().Next(1, 1000000);
        
        public int OwnWeight { get; }
        public int Height { get; }
        public int Depth { get; }
        public string SerialNumber { get; }
        public int MaxLoadCapacity { get; }
        public double CurrentLoad { get; protected set; }

        protected Container(int ownWeight, int height, int depth, int maxLoadCapacity, string type)
        {
            OwnWeight = ownWeight;
            Height = height;
            Depth = depth;
            MaxLoadCapacity = maxLoadCapacity;
            SerialNumber = GenerateSerialNumber(type);
            CurrentLoad = ownWeight;
        }

        private static string GenerateSerialNumber(string type)
        {
            return $"KON-{type}-{_counter++}";
        }

        public virtual void Load(int weight)
        {
            if (CurrentLoad + weight > MaxLoadCapacity)
            {
                throw new OverfillException($"Przekroczono maksymalną ładowność kontenera {SerialNumber}!");
            }
            CurrentLoad += weight;
        }

        public virtual void Unload()
        {
            CurrentLoad = OwnWeight;
        }
        
        public void ContainerInfo()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Container Informations:");
            Console.WriteLine($"SerialNumber: {SerialNumber}");
            Console.WriteLine($"Own weight: {OwnWeight}");
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Max load capacity: {MaxLoadCapacity}");
            Console.WriteLine($"Deptht: {Depth}");
            Console.WriteLine($"Current load: {CurrentLoad}");
            Console.WriteLine("****************************");
        }
    }

    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
    }
    
    
}