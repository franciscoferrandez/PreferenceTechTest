using Application.DTO;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private IIssueService _issueService;
        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        // GET: api/<IssuesController>
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _issueService.GetIssues();
        }

        // GET api/<IssuesController>/5
        [HttpGet("{id}")]
        public IssueDTO Get(int id)
        {
            return _issueService.Get(id);
        }

        // POST api/<IssuesController>
        [HttpPost]
        public void Post([FromBody] IssueDTO value)
        {
            IssueDTO issue = _issueService.Save(value);
        }

        // PUT api/<IssuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IssueDTO value)
        {
            value.Id = id;
            IssueDTO issue = _issueService.Save(value);
        }

        // DELETE api/<IssuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _issueService.Delete(id);
        }
    }
}
