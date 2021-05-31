using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(Issue issue)
        {
            _context.Issue.Remove(issue);
            _context.SaveChanges();
        }

        public Issue GetIssue(int id)
        {
            Issue result = null;
            result = _context.Issue.FirstOrDefault(item => item.Id == id);
            return result;
        }

        public void Save(Issue issue)
        {
            _context.Issue.Add(issue);
            _context.SaveChanges();
            _context.Entry(issue).State = EntityState.Detached;
        }

        public void Update(Issue issue)
        {
            _context.Issue.Update(issue);
            _context.SaveChanges();
            _context.Entry(issue).State = EntityState.Detached;
        }
    }
}
