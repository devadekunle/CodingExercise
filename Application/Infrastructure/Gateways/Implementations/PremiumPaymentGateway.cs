using Application.Infrastructure.Gateways.Interfaces;
using Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Gateways.Implementations
{
    public class PremiumPaymentGateway : IPremiumPaymentService
    {
        private readonly int RetryPolicy = 3;
        
        public Task<bool> ProcessPaymentAsync(PaymentDto model, bool isRetry = false)
        {
            int count = 1;
            if (!(model.Amount > 500)) { 
            
                throw new ArgumentException("Cheap Payment Gateway can only process amounts greater than 500 pounds.");
            }

            var random = new Random();
            var result = random.Next(100) % 2 == 0;
            while (!result)
            {
                if (count <= RetryPolicy)
                {
                    result = random.Next(100) % 2 == 0;
                    if (result)
                    {
                        break;

                    }
                    count++;
                }
                break;
            }
            return Task.FromResult(result);
        }
    }
}
