using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IIssueRepository
    {
        IEnumerable<Issue> GetIssues();
        Issue GetIssue(int id);
        void Save(Issue issue);
        void Update(Issue issue);
        void Delete(Issue issue);
    }
}
