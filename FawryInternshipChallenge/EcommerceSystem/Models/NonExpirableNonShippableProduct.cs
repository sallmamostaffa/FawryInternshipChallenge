namespace EcommerceSystem.Models
{
    public class NonExpirableNonShippableProduct : Product
    {
        public NonExpirableNonShippableProduct(string name, double price, int quantity)
            : base(name, price, quantity)
        {
        }

        public override bool IsExpired() => false;
    }
}