using CrudAssignment.Data;
using CrudAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace CrudAssignment.Pages.Shared
{
    public class DetailsModel : PageModel
    {
        private readonly IItemRepository _repo;

        public Item Item { get; set; } = default!;

        public DetailsModel(IItemRepository repo)
        {
            _repo = repo;
        }
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
