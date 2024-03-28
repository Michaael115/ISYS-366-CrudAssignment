using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudAssignment.Data;
using CrudAssignment.Models;

namespace CrudAssignment.Pages.Items
{
    public class DetailsModel : PageModel
    {
        private readonly CrudAssignment.Data.CrudAssignmentContext _context;



        public DetailsModel(CrudAssignment.Data.CrudAssignmentContext context)
        {
            _context = context;
        }

        public Item Item { get; set; } = default!;

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Item = item;
            }
            return Page();
        }
    }
}
