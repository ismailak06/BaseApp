using BaseApp.Domain.Common;
using BaseApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Domain.Entities
{
    public class Product : AuditableEntity, ISoftDelete
    {
        public Product() { }
        public Product(int productId)
        {
            Id = productId;
        }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }

        public void SoftDelete()
        {
            IsDeleted = true;
            DeletionDate = DateTime.Now;
        }
    }
}