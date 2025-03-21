using System;
using System.Collections.Generic;

namespace Containers
{
    public class ColdContainer : Container
    {
        private static readonly Dictionary<string, double> ProductTemperatures = new()
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };

        public string ProductType { get; }
        public double Temperature { get; }

        public ColdContainer(int ownWeight, int height, int depth, int maxLoadCapacity, string productType, double temp)
            : base(ownWeight, height, depth, maxLoadCapacity, "C")
        {
            if (!ProductTemperatures.ContainsKey(productType))
            {
                throw new ArgumentException($"Invalid product type: {productType}");
            }

            if (temp <= ProductTemperatures[productType])
            {
                throw new ArgumentException($"Invalid temperature: {temp}");
            }

            ProductType = productType;
            Temperature = temp;
        }
        
        public void Load(int weight, string productType)
        {
            if (productType != ProductType)
            {
                throw new ArgumentException($"Kontener może przechowywać tylko {ProductType}!");
            }

            base.Load(weight);
        }

    }
}