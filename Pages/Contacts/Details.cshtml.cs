using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Contacts.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public DetailsModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

      public Contact Contact { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FirstOrDefaultAsync(m => m.ID == id);
            if (contact == null)
            {
                return NotFound();
            }
            else 
            {
                Contact = contact;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }
            var contact = await _context.Contact.FindAsync(id);

            if (contact != null)
            {
                Contact = contact;
                _context.Contact.Remove(Contact);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
