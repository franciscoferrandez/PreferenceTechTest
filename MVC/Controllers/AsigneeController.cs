using Application.DTO;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class AsigneeController : Controller
    {
        private IAsigneeService _asigneeService;
        public AsigneeController(IAsigneeService asigneeService)
        {
            _asigneeService = asigneeService;
        }
        public IActionResult Index()
        {
            List<AsigneeDTO> model = _asigneeService.GetAsignees();
            return View(model);
        }
    }
}
