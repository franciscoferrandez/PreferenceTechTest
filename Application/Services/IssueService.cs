using Application.DTO;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class IssueService: IIssueService
    {

        public IIssueRepository _issueRepository;
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public IssueViewModel GetIssues()
        {
            return new IssueViewModel()
            {
                Issues = _issueRepository.GetIssues()
            };
        }

        public IssueDTO Save(IssueDTO issue)
        {
            Issue u = new Issue()
            {
                Id = issue.Id,
                Title = issue.Title,
            };
            if (u.Id == 0)
            {
                _issueRepository.Save(u);
            }
            else
            {
                _issueRepository.Update(u);
            }
            issue.Id = u.Id;
            issue.Title = u.Title;
            issue.Created = u.Created;
            return issue;
        }

        public void Delete(int issueId)
        {
            Issue issue = _issueRepository.GetIssue(issueId);
            if (issue == null) throw new ArgumentException();
            _issueRepository.Delete(issue);
        }
    }
}
