using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrudAssignment.Data;
using CrudAssignment.Models;
using Microsoft.Extensions.Hosting;
using CrudAssignment.Utilities;

namespace CrudAssignment.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly IItemRepository _repo;
        private readonly IWebHostEnvironment _env;

        public CreateModel(IItemRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
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

            if(HttpContext.Request.Form.Files.Count > 0)
            {
               
                Item.PictureUrl = FileHelper.UploadNewImage(_env, HttpContext.Request.Form.Files[0]);
            }

            _repo.AddItem(Item);

            return RedirectToPage("./Index");
        }


    }
}
