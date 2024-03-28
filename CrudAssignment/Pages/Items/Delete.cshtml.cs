using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudAssignment.Data;
using CrudAssignment.Models;
using System.CodeDom;

namespace CrudAssignment.Pages.Items
{
    public class DeleteModel : PageModel
    {
        private readonly CrudAssignment.Data.CrudAssignmentContext _context;

        private readonly IItemRepository _repo;

        public DeleteModel(CrudAssignment.Data.CrudAssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
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


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                Item = item;
               await _repo.DeleteItem(id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
