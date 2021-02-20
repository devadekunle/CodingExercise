using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.EntityConfiguration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.CreditCardNumber)
                .IsRequired()
                .HasMaxLength(19);

            builder.Property(p => p.CardHolder)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.ExpirationDate)
                .IsRequired();

            builder.Property(p => p.Amount).IsRequired();
        }
    }
}
