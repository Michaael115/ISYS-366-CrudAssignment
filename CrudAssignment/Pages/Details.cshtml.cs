using CrudAssignment.Data;
using CrudAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudAssignment.Pages
{

    [Authorize]
    public class DetailsModel : PageModel
    {

        private readonly IItemRepository _repo;

        public DetailsModel(IItemRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]


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