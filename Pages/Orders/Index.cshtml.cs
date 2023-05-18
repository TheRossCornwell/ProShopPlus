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
    public class IndexModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public IndexModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;

        public List<Order> OrderList { get; set; } = default!;
        public List<Contact> ContactList { get; set; } = default!;


        public async Task OnGetAsync()
        {
            var orders = from c in _context.Order
                         select c;


            orders = orders.Where(c => !HideList.Contains(c.Progress));
            orders = orders.Where(c => c.ID != 0);

            var contacts = from c in _context.Contact
                           select c;
            ContactList = await contacts.ToListAsync();

            //Search function
            if (!string.IsNullOrEmpty(SearchString))
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                orders = orders.Where(c => c.Contact.Name.ToLower().Contains(SearchString.ToLower()));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            ViewData["ContactID"] = new SelectList(_context.Contact, "ID", "Name");

            orders = orders.OrderBy(c => c.StartDate);
            OrderList = await orders.ToListAsync();
        }

        // Search Properites
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } // Search Function variable

        [BindProperty(SupportsGet = true)]
        public List<string> HideList { get; set; }
    }
}
