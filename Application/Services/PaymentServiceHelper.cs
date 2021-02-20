using Application.Infrastructure.Gateways.Implementations;
using Application.Infrastructure.Gateways.Interfaces;

namespace Application.Services
{
    public static class PaymentServiceHelper
    {

        public static IPaymentGateway GetPaymentGateway( decimal amount)
        {
            if (amount < 20)
            {
                return new CheapPaymentGateway();
            }
            if (amount > 20 && amount <= 500)
            {
                return new ExpensivePaymentGateway();
            }
            if (amount > 500)
            {
                return new PremiumPaymentGateway();
            }

            return default;
        }
    }
}