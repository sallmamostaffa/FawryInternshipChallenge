using EcommerceSystem.Interfaces;

namespace EcommerceSystem.Services
{
    public class ShippingService
    {
        public void Ship(List<IShippable> shippableItems)
        {
            if (shippableItems.Any())
            {
                Console.WriteLine("** Shipment notice **");
                double totalWeight = 0;
                foreach (var item in shippableItems)
                {
                    Console.WriteLine($"{item.GetName()} {item.GetWeight()}g");
                    totalWeight += item.GetWeight();
                }
                Console.WriteLine($"Total package weight {totalWeight / 1000}kg");
            }
        }
    }
}