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
    public class AsigneesController : ControllerBase
    {
        private IAsigneeService _asigneeService;
        public AsigneesController(IAsigneeService asigneeService)
        {
            _asigneeService = asigneeService;
        }

        // GET: api/<AsigneesController>
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return _asigneeService.GetAsignees();
        }
    }
}
