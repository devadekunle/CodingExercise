using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebUI.Models.Requests
{
    public class PaymentRequest : IValidatableObject
    {
        [Required]
        [MaxLength(19)]
        
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

        public string SecurityCode { get; set; }
        [Required]

        
        public decimal Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ExpirationDate < DateTime.Now)
            {
                yield return new ValidationResult("Expiration date must be in the future", new[] { nameof(ExpirationDate) });
            }
            var rgx = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");
            if (!rgx.IsMatch(CreditCardNumber))
            {
                yield return new ValidationResult("Credit card number not valid", new[] { nameof(CreditCardNumber) });

            }
            if (Amount < 0)
            {
                yield return new ValidationResult("Amount must be a postiive value", new[] { nameof(Amount) });
            }
        }
    }
}
