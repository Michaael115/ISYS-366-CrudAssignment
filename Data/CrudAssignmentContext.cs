using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudAssignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UI.Data
{
    public class CrudAssignmentContext : IdentityDbContext
    {
        public CrudAssignmentContext (DbContextOptions<CrudAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<CrudAssignment.Models.Item> Item { get; set; } = default!;
    }
}
