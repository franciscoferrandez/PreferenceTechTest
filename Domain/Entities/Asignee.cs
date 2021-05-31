using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Asignee : AuditableEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
    }
}
