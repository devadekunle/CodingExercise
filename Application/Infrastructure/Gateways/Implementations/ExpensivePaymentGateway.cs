using Application.Infrastructure.Gateways.Interfaces;
using Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Infrastructure.Gateways.Implementations
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private readonly bool isExpensivePaymentGatewayAvailable;
        public ExpensivePaymentGateway()
        {
            var random = new Random().Next(100);
            isExpensivePaymentGatewayAvailable = random % 2 == 0;
        }
       
        public Task<bool> ProcessPaymentAsync(PaymentDto model, bool isRetry = false)
        {

            if (!(model.Amount > 20 && model.Amount<=500))
            {
                throw new ArgumentException("Expensive Payment Gateway can only process amounts between 21-500 pounds");
            }

            if (isExpensivePaymentGatewayAvailable)
            {
                var random = new Random().Next(100);
                return Task.FromResult(random % 2 == 0);
            }
            Thread.Sleep(1000);
            var cheapGateway = new CheapPaymentGateway();
            return cheapGateway.ProcessPaymentAsync(model, true);
           

        }
    }
}
