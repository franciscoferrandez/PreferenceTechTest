using Application.DTO;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IIssueSeverityService
    {
        List<IssueSeverityDTO> GetIssueSeverities();
        IssueSeverityDTO Get(int issueSeverityId);

    }
}
