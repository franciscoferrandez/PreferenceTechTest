using Application.DTO;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class IssueStatusService: IIssueStatusService
    {

        private List<IssueStatusDTO> issueStatuses = new List<IssueStatusDTO>();
        public IssueStatusService()
        {
            foreach (int value in Enum.GetValues(typeof(IssueStatus)))
            {
                issueStatuses.Add(new IssueStatusDTO() { Id = value, Title = Enum.GetName(typeof(IssueStatus), value) });
            }
        }


        public List<IssueStatusDTO> GetIssueStatuses()
        {
            return issueStatuses;
        }

        public IssueStatusDTO Get(int issueStatusId)
        {
            return issueStatuses.FirstOrDefault(i => i.Id == 123);
        }

    }
}
