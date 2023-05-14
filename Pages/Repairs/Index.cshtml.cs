using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Repairs
{
    public class IndexModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public IndexModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

        
        public List<Repair> RepairList { get; set; } = default!;
        public List<Contact> ContactList { get; set; } = default!;
        public async Task OnGetAsync()
        {
            var repairs = from c in _context.Repair
                          select c;
            
            
            repairs = repairs.Where(c => !HideList.Contains(c.Progress));
            
            

            


            //Creating 'contacts & repairs' variable
            var contacts = from c in _context.Contact
                           select c;
            ContactList = await contacts.ToListAsync();
            //repairs = from c in _context.Repair
                          // select c;
            repairs = repairs.Where(c => c.ID != 0);

            //View Function
            




            //Search function
            if (!string.IsNullOrEmpty(SearchString))
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                repairs = repairs.Where(c => c.Contact.Name.ToLower().Contains(SearchString.ToLower()));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            ViewData["ContactID"] = new SelectList(_context.Contact, "ID", "Name");
            RepairList = await repairs.ToListAsync();
        }

        // Search Properites
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } // Search Function variable

        [BindProperty(SupportsGet = true)]
        public List<string> HideList { get; set; }

        




        }
    }

