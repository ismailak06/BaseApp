using BaseApp.Domain.Common.EntityRules;
using BaseApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            AuditableEntityConfiguration<Category>.SetProperties(builder);
            SoftDeleteConfiguration<Category>.SetProperties(builder);
            UserRules userRules = new UserRules();

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired();
        }
    }
}