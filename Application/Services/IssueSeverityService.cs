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
    public class IssueSeverityService: IIssueSeverityService
    {

        private List<IssueSeverityDTO> issueSeverities = new List<IssueSeverityDTO>();
        public IssueSeverityService()
        {
            foreach (int value in Enum.GetValues(typeof(IssueSeverity)))
            {
                issueSeverities.Add(new IssueSeverityDTO() { Id = value, Title = Enum.GetName(typeof(IssueSeverity), value) });
            }
        }


        public List<IssueSeverityDTO> GetIssueSeverities()
        {
            return issueSeverities;
        }

        public IssueSeverityDTO Get(int issueSeverityId)
        {
            return issueSeverities.FirstOrDefault(i => i.Id == issueSeverityId);
        }

    }
}
