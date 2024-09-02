using BaseApp.Domain.Common;
using BaseApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Domain.Entities
{
    public class Category : AuditableEntity, ISoftDelete
    {
        public Category() { }
        public Category(int categoryId)
        {
            Id = categoryId;
        }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }

        public void SoftDelete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }
    }
}
