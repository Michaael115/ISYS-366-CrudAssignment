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
        private readonly CrudAssignment.Data.CrudAssignmentContext _context;

        public IndexModel(CrudAssignment.Data.CrudAssignmentContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Name{ get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ItemName { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> nameQuery = from m in _context.Item
                                            orderby m.Name
                                            select m.Name;


            var items = from m in _context.Item
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.Name.Contains(SearchString));
            }


            if (!string.IsNullOrEmpty(ItemName))
            {
                items = items.Where(x => x.Name == ItemName);
            }
            Name = new SelectList(await nameQuery.Distinct().ToListAsync());
            Item = await _context.Item.ToListAsync();
        }
    }
}
