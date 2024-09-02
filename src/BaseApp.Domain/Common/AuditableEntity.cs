using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Domain.Common
{
    public abstract class AuditableEntity : Entity<int>
    {
        public AuditableEntity()
        {
            CreationDate = DateTime.Now;
        }
        public int CreatorId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int? ModifierId { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        private void SetCreationInfos(int creatorId)
        {
            CreatorId = creatorId;
            CreationDate = DateTime.Now;
        }

        public void SetModifieInfos(int modifierId)
        {
            ModifierId = modifierId;
            ModifiedDate = DateTime.Now;
        }
    }
}