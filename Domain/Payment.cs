using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }

        public decimal Amount { get; set; }

        public PaymentState PaymentState { get; set; }
    }
}
