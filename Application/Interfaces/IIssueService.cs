using Application.DTO;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IIssueService
    {
        IssueViewModel GetIssuesViewModel();
        List<IssueDTO> GetIssues();
        IssueDTO Save(IssueDTO issue);
        IssueDTO Get(int issueId);
        IssueDTO Delete(int issueId);
    }
}
