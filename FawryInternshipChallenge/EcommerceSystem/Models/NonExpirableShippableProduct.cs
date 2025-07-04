using EcommerceSystem.Interfaces;

namespace EcommerceSystem.Models
{
    public class NonExpirableShippableProduct : Product, IShippable
    {
        private double Weight { get; set; }

        public NonExpirableShippableProduct(string name, double price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public override bool IsExpired() => false;
        public double GetWeight() => Weight;
    }
}
