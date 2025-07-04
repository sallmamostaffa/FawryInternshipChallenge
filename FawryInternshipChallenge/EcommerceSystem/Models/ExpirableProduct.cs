namespace EcommerceSystem.Models
{
    public class ExpirableProduct : Product
    {
        private DateTime ExpiryDate { get; set; }

        public ExpirableProduct(string name, double price, int quantity, DateTime expiryDate)
            : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override bool IsExpired() => DateTime.Now > ExpiryDate;
    }
}