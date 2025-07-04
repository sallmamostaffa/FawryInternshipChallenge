namespace EcommerceSystem.Models
{
    public class Cart
    {
        private Dictionary<Product, int> Items { get; set; } = new();

        public void Add(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");
            if (quantity > product.GetQuantity())
                throw new ArgumentException($"Not enough stock for {product.GetName()}. Available: {product.GetQuantity()}");
            if (product.IsExpired())
                throw new ArgumentException($"{product.GetName()} is expired.");

            if (Items.ContainsKey(product))
                Items[product] += quantity;
            else
                Items[product] = quantity;

            product.ReduceQuantity(quantity);
        }

        public Dictionary<Product, int> GetItems() => Items;
    }
}