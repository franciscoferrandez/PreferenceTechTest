using Application.DTO;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IIssueService
    {
        IssueViewModel GetIssues();
        IssueDTO Save(IssueDTO issue);

        void Delete(int issueId);
    }
}
