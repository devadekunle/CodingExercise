using Application.Services;
using Application.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.Requests;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(c => c.Errors).Select(c => c.ErrorMessage));
            }

            var paymentDto = new PaymentDto
            {
                Amount = request.Amount,
                CardHolder = request.CardHolder,
                CreditCardNumber = request.CreditCardNumber,
                ExpirationDate = request.ExpirationDate,
                SecurityCode = request.SecurityCode,
            };

            await  _paymentService.ProcessPayment(paymentDto);
            return Ok();  
        }
    }
}
