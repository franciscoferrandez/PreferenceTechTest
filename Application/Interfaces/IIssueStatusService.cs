using Application.DTO;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IIssueStatusService
    {
        List<IssueStatusDTO> GetIssueStatuses();
        IssueStatusDTO Get(int issueStatusId);

    }
}
