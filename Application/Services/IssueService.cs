using Application.Interfaces;
using Application.ViewModels;
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
    }
}
