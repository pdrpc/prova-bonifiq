using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
	public class OrderService
	{
        private readonly IDictionary<string, IPaymentHandler> _paymentHandlers;

        public OrderService()
        {
            _paymentHandlers= new Dictionary<string, IPaymentHandler>
            {
                { "pix", new PixPaymentHandler() },
                { "creditcard", new CreditCardPaymentHandler() },
                { "paypal", new PayPalPaymentHandler() }
            };
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            if (!_paymentHandlers.TryGetValue(paymentMethod, out var paymentStrategy))
            {
                throw new ArgumentException($"Invalid payment method: {paymentMethod}");
            }

            await paymentStrategy.Pay(paymentValue, customerId);

            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
