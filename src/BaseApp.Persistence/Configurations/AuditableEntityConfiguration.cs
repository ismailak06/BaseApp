using BaseApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Persistence.Configurations
{
    public static class AuditableEntityConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public static EntityTypeBuilder<TEntity> SetProperties(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.CreatorId)
                .IsRequired();
            builder.Property(m => m.CreationDate)
                .IsRequired();

            builder.Property(m => m.ModifierId);
            builder.Property(m => m.ModifiedDate);

            return builder;
        }
    }
}