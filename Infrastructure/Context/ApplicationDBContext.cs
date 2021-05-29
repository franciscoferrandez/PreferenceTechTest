using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities;

namespace Infrastructure.Context
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Issue> Issue { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }
    }
}
