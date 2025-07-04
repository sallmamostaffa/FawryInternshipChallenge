using EcommerceSystem.Models;
using EcommerceSystem.Services;

namespace EcommerceSystem
{
    public class Program
    {
        public static void Main()
        {
            var cheese = new ExpirableProduct("Cheese", 100, 5, DateTime.Now.AddDays(10));
            var biscuits = new ExpirableProduct("Biscuits", 150, 3, DateTime.Now.AddDays(5));
            var tv = new NonExpirableShippableProduct("TV", 1000, 3, 700);
            var scratchCard = new NonExpirableNonShippableProduct("Mobile Scratch Card", 50, 10);

            var customer = new Customer("Hany", 1000);

            var cart = new Cart();
            try
            {
                cart.Add(cheese, 2);
                cart.Add(biscuits, 1);
                cart.Add(scratchCard, 1);

                var checkoutService = new CheckoutService();
                checkoutService.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
