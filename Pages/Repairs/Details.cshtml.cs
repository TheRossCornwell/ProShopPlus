﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Repairs
{
    public class DetailsModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public DetailsModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

      public Repair Repair { get; set; } = default!;
        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["ContactID"] = new SelectList(_context.Contact, "ID", "Name");
            if (id == null || _context.Repair == null)
            {
                return NotFound();
            }
            
            var repair = await _context.Repair.FirstOrDefaultAsync(m => m.ID == id);
            
            if (repair == null)
            {
                return NotFound();
            }
            else 
            {
                var contact = await _context.Contact.FirstOrDefaultAsync(m => m.ID == repair.ContactID);
                Contact = contact;
                Repair = repair;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Repair == null)
            {
                return NotFound();
            }
            var repair = await _context.Repair.FindAsync(id);

            if (repair != null)
            {
                Repair = repair;
                _context.Repair.Remove(Repair);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
