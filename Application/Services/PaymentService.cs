using Application.DataAccess.Repository;
using Application.DataAccess.UnitOfWork;
using Application.Infrastructure.Gateways.Implementations;
using Application.Infrastructure.Gateways.Interfaces;
using Application.Services.DTOs;
using Domain;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentService :  IPaymentService
    {
         readonly IRepository<Payment> _paymentRepository;
        readonly IUnitOfWork _unitOfWork;

        public PaymentService(IRepository<Payment> paymentRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }

        public  async Task ProcessPayment(PaymentDto paymentDto)
        {
            try
            {
                var payment = new Payment
                {
                    Amount = paymentDto.Amount,
                    CardHolder = paymentDto.CardHolder,
                    CreditCardNumber = paymentDto.CreditCardNumber,
                    ExpirationDate = paymentDto.ExpirationDate,
                    PaymentState = new PaymentState
                    {
                        PaymentStatus = PaymentStatus.Pending,
                    },
                    SecurityCode = paymentDto.SecurityCode,
                };
                await _paymentRepository.InsertAsync(payment);
                await _unitOfWork.SaveChangesAsync();

                IPaymentGateway paymentGateway = PaymentServiceHelper.GetPaymentGateway(payment.Amount);
                var isProcessed = await paymentGateway.ProcessPaymentAsync(paymentDto);

                payment.PaymentState.PaymentStatus = isProcessed ? PaymentStatus.Processed : PaymentStatus.Failed;
               await  _unitOfWork.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
