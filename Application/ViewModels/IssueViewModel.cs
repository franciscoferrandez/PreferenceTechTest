using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class IssueViewModel
    {
        public IEnumerable<Issue> Issues { get; set; }
    }
}
