internal class Program
{
    private static void Main(string[] args)
    {
        var order = new Order(new CashPayment());
        order.Checkout(1000);
        order = new Order(new CreditCardPayment());
        order.Checkout(1000);
    }
    class Order
    {
        private readonly IPayments _payment;
        public Order(IPayments payment)
        {
            _payment = payment;
        }
        public void Checkout(decimal amount)
        {
            _payment.Pay(amount);
        }
    }
    interface IPayments
    {
        void Pay(decimal amount);
    }
    class CashPayment : IPayments
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Cash Payment :{Math.Round(amount):N0}");
        }
    }

    class CreditCardPayment : IPayments
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Credit Card Payment :{Math.Round(amount):N0}");
        }
    }

}