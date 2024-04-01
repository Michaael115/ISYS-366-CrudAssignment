using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrudAssignment.Data;
using CrudAssignment.Models;

namespace CrudAssignment.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly IItemRepository _repo;

        public CreateModel(IItemRepository repo)
        {
            _repo = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                _repo.AddItem(Item);

            return RedirectToPage("./Index");
        }
    }
}
