using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        public ApplicationDBContext _context;
        public IssueRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Issue> GetIssues()
        {
            return _context.Issue;
        }
    }
}
