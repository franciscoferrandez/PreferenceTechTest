using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
     public abstract class AuditableEntityDTO
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
