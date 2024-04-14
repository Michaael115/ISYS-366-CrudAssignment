using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudAssignment.Models;

namespace UI.Data
{
    public class CrudAssignmentContext : DbContext
    {
        public CrudAssignmentContext (DbContextOptions<CrudAssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<CrudAssignment.Models.Item> Item { get; set; } = default!;
    }
}
