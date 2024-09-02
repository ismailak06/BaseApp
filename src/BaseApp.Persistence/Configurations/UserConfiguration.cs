using BaseApp.Domain.Common.EntityRules;
using BaseApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            AuditableEntityConfiguration<User>.SetProperties(builder);
            SoftDeleteConfiguration<User>.SetProperties(builder);
            UserRules userRules = new UserRules();

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Username)
                .HasMaxLength(userRules.UsernameRules.MaxLength)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(userRules.EmailRules.MaxLength)
                .IsRequired();

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.PasswordSalt)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}