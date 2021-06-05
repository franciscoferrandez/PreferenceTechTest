using Application.DTO;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueStatusController : ControllerBase
    {
        private IIssueStatusService _issueStatusService;
        public IssueStatusController(IIssueStatusService issueStatusService)
        {
            _issueStatusService = issueStatusService;
        }

        [HttpGet]
        public List<IssueStatusDTO> Get()
        {
            return _issueStatusService.GetIssueStatuses();
        }

        [HttpGet("{id}")]
        public IssueStatusDTO Get(int id)
        {
            return _issueStatusService.Get(id);
        }

    }
}
