using Application.Infrastructure.Gateways.Interfaces;
using Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Gateways.Implementations
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public Task<bool> ProcessPaymentAsync(PaymentDto model, bool isRetry = false)
        {
            if (!isRetry)
            {
                if (model.Amount > 20)
                {
                    throw new ArgumentOutOfRangeException("Cheap Payment Gateway can only process amounts < than 20 pounds.");
                } 
            }

            var random = new Random().Next(100);
            return Task.FromResult(random % 2 == 0);


        }
    }
}
