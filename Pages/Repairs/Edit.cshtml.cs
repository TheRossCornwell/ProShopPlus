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

namespace ProShopPlus.Pages.Repairs
{
    public class EditModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public EditModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Repair Repair { get; set; } = default!;
        public List<Contact> ContactList { get; set; } = default!;
        public List<Repair> RepairList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var contacts = from c in _context.Contact
                           select c;
            contacts = contacts.Where(c => c.ID != 0);
            ContactList = await contacts.ToListAsync();
            var repairContact = from c in _context.Repair
                                select c;
            
            RepairList = await repairContact.ToListAsync();
            if (id == null || _context.Repair == null)
            {
                Repair = new Repair();
                
            }
            else
            {
                var repair = await _context.Repair.FirstOrDefaultAsync(m => m.ID == id);
                repairContact = repairContact.Where(c => c.ID == id);
                RepairList = await repairContact.ToListAsync();

                if (repair == null)
                {
                    return NotFound();
                }
                Repair = repair;
            }
            ViewData["ContactID"] = new SelectList(_context.Contact, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (id == null)
            {
                _context.Repair.Add(Repair);
            }
            else
            {
                _context.Attach(Repair).State = EntityState.Modified;
            }

            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairExists(Repair.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RepairExists(int id)
        {
          return (_context.Repair?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
