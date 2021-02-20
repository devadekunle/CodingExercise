using Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPaymentService
    {
        Task ProcessPayment(PaymentDto payment);
    }
}
