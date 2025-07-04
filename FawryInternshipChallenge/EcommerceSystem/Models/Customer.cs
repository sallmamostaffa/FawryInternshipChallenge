namespace EcommerceSystem.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public void DeductBalance(double amount) => Balance -= amount;
    }
}