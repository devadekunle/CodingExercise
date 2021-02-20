using Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Gateways.Interfaces
{
    public interface IPaymentGateway
    {
        Task<bool> ProcessPaymentAsync(PaymentDto model, bool isRetry = false);
       
    }
}
