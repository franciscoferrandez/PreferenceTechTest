using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Issue, IssueDTO>();
            CreateMap<IssueDTO, Issue>();
        }
    }
}
