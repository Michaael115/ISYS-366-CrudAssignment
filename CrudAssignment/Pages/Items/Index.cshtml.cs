using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudAssignment.Data;
using CrudAssignment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudAssignment.Pages.Items
{
    public class IndexModel : PageModel
    {

        private readonly IItemRepository _repo;

        public IndexModel(IItemRepository repo)
        {
            _repo = repo;
        }

        public IList<Item> Item { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Name{ get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ItemName { get; set; }

        public async Task OnGetAsync()
        {

            Item = (IList<Item>)_repo.GetAllItems(SearchString);
        }
    }
}
