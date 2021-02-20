using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PaymentState
    {
        public Guid Id { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Guid PaymentId { get; set; }
    }
}
