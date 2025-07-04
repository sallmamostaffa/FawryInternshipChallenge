using EcommerceSystem.Interfaces;
using EcommerceSystem.Models;

namespace EcommerceSystem.Services
{
    public class CheckoutService
    {
        private const double ShippingCostPerKg = 10;

        public void Checkout(Customer customer, Cart cart)
        {
            if (!cart.GetItems().Any())
                throw new InvalidOperationException("Cart is empty.");

            double subtotal = 0;
            List<IShippable> shippableItems = new();

            foreach (var item in cart.GetItems())
            {
                var product = item.Key;
                int quantity = item.Value;

                if (product.IsExpired())
                    throw new InvalidOperationException($"{product.GetName()} is expired.");
                if (quantity > product.GetQuantity())
                    throw new InvalidOperationException($"{product.GetName()} is out of stock.");

                subtotal += product.GetPrice() * quantity;

                if (product is IShippable shippable)
                {
                    for (int i = 0; i < quantity; i++)
                        shippableItems.Add(shippable);
                }
            }

            double totalWeightKg = shippableItems.Sum(item => item.GetWeight()) / 1000;
            double shippingFees = totalWeightKg * ShippingCostPerKg;
            double totalAmount = subtotal + shippingFees;

            if (totalAmount > customer.Balance)
                throw new InvalidOperationException("Insufficient balance.");

            new ShippingService().Ship(shippableItems);
            customer.DeductBalance(totalAmount);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.GetItems())
            {
                Console.WriteLine($"{item.Value}x {item.Key.GetName()} {item.Key.GetPrice() * item.Value}");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal {subtotal}");
            Console.WriteLine($"Shipping {shippingFees}");
            Console.WriteLine($"Amount {totalAmount}");
            Console.WriteLine($"Customer balance after payment: {customer.Balance}");
        }
    }
}
