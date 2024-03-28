﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudAssignment.Data;
using CrudAssignment.Models;

namespace CrudAssignment.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly IItemRepository _repo;

        public EditModel(IItemRepository repo)
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

            //id.value

            var tempItem = await _repo.GetItemAsync(id.Value);
            if (tempItem == null)
            {
                return NotFound();
            }
            Item = tempItem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(!await _repo.UpdateItemAysnc(Item))
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

  
    }
}
