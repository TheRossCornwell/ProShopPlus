using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public DetailsModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

      public Order Order { get; set; } = default!;
        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["ContactID"] = new SelectList(_context.Contact, "ID", "Name");
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                var contact = await _context.Contact.FirstOrDefaultAsync(m => m.ID == order.ContactID);
                Contact = contact;
                Order = order;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);

            if (order != null)
            {
                Order = order;
                _context.Order.Remove(Order);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
