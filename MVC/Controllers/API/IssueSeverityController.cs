using Application.DTO;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueSeverityController : ControllerBase
    {
        private IIssueSeverityService _issueSeverityService;
        public IssueSeverityController(IIssueSeverityService issueSeverityService)
        {
            _issueSeverityService = issueSeverityService;
        }

        [HttpGet]
        public List<IssueSeverityDTO> Get()
        {
            return _issueSeverityService.GetIssueSeverities();
        }

        [HttpGet("{id}")]
        public IssueSeverityDTO Get(int id)
        {
            return _issueSeverityService.Get(id);
        }

    }
}
