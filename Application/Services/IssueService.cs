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

        public IssueViewModel GetIssuesViewModel()
        {
            return new IssueViewModel()
            {
                Issues = _issueRepository.GetIssues()
            };
        }

        public List<IssueDTO> GetIssues()
        {
            return ObjectMapper.Mapper.Map<List<IssueDTO>>(_issueRepository.GetIssues());
        }

        public IssueDTO Save(IssueDTO issue)
        {
            Issue u = ObjectMapper.Mapper.Map<Issue>(issue);
            if (u.Id == 0)
            {
                _issueRepository.Save(u);
            }
            else
            {
                _issueRepository.Update(u);
            }
            issue = ObjectMapper.Mapper.Map<IssueDTO>(u);
            return issue;
        }

        public IssueDTO Get(int issueId)
        {
            Issue issue = _issueRepository.GetIssue(issueId);
            if (issue == null) throw new ArgumentException();
            return ObjectMapper.Mapper.Map<IssueDTO>(issue);
        }
        public IssueDTO Delete(int issueId)
        {
            Issue issue = _issueRepository.GetIssue(issueId);
            if (issue == null) throw new ArgumentException();
            _issueRepository.Delete(issue);
            return ObjectMapper.Mapper.Map<IssueDTO>(issue);
        }
    }
}
