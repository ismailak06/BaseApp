using BaseApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Persistence.Configurations
{
    public static class SoftDeleteConfiguration<TEntity> where TEntity : class, ISoftDelete
    {
        public static EntityTypeBuilder<TEntity> SetProperties(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.IsDeleted);
            builder.Property(p => p.DeletionDate);
            builder.HasQueryFilter(p => !p.IsDeleted);
            return builder;
        }
    }
}