using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Issue : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IssueSeverity Severity { get; set; }

        public IssueStatus Status { get; set; }

        public int Asignee { get; set; }


    }
}
