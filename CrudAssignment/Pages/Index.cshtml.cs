using CrudAssignment.Data;
using CrudAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IItemRepository _repo;

        public IEnumerable<Item> Items { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? filter { get; set; }



        public IndexModel(ILogger<IndexModel> logger, IItemRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }


        public IList<Item> ItemModels { get; set; } = default;

        public async Task OnGetAsync()
        {
         //  Items = _repo.GetItemsAsync(filter);
            Items = (IList <Item>) _repo.GetAllItems("");
        }

    }
}
