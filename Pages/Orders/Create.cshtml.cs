using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public CreateModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ContactID"] = new SelectList(_context.Contact, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Order == null || Order == null)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
