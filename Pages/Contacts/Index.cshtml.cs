using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Contacts.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public IndexModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

        
        public List<Contact> ContactList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //Creating 'contacts' variable
            var contacts = from c in _context.Contact
                           select c;

            //Search function
            if (!string.IsNullOrEmpty(SearchString))
            {
                contacts = contacts.Where(c => c.Name.ToLower().Contains(SearchString.ToLower()));
            }

            //Sort by name
            contacts = contacts.OrderBy(c => c.Name.ToLower());

            ContactList = await contacts.ToListAsync();
        }

        // Search Properites
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } // Search Function variable
    }
}
