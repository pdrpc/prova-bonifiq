using ProvaPub.Interfaces;

namespace ProvaPub.Models
{
    public class PaymentHandlers
    {
    }

    public class PayPalPaymentHandler : IPaymentHandler
    {
        public async Task Pay(decimal paymentValue, int customerId)
        {
            //Implementation for PayPal Payment
        }
    }

    public class CreditCardPaymentHandler : IPaymentHandler
    {
        public async Task Pay(decimal paymentValue, int customerId)
        {
            //Implementation for Credit Card payment
        }
    }

    public class PixPaymentHandler : IPaymentHandler
    {
        public async Task Pay(decimal paymentValue, int customerId)
        {
            //Implementation for pix payment
        }
    }
}
