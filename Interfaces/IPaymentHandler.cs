namespace ProvaPub.Interfaces
{
    public interface IPaymentHandler
    {
        Task Pay(decimal paymentValue, int customerId);
    }
}
