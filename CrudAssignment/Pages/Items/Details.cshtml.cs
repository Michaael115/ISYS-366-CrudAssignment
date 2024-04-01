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
        private readonly IItemRepository _repo;
        public DetailsModel(IItemRepository repo)
        {
            _repo = repo;
        }

        public Item Item { get; set; } = default!;

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _repo.GetById(id.Value);
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
