using CrudAssignment.Data;
using CrudAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IItemRepository _repo;

        public IndexModel(IItemRepository repo)
        {
            _repo = repo;
        }

        public IList<Item> ItemModels { get; set; } = default;

        public async Task OnGetAsync()
        {
            ItemModels = (IList <Item>) _repo.GetAllItems("");
        }

    }
}
