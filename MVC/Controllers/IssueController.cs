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
    public class IssueController : Controller
    {
        private IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }
        public IActionResult Index()
        {
            IssueViewModel model = _issueService.GetIssues();
            return View(model);
        }
    }
}
