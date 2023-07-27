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
        public List<Repair> RepairList { get; set; } = default!;
        public List<Repair> CompleteRepairList { get; set; } = default!;
        public List<Order> OrderList { get; set; } = default!;
        public List<Order> CompleteOrderList { get; set; } = default!;
        public List<Lesson> LessonList { get; set; } = default!;
        public List<Lesson> CompleteLessonList { get; set; } = default!;

        public int RepairViewID { get; set; } = default!;

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
                var repairs = from r in _context.Repair
                              where r.ContactID == contact.ID
                              select r;
                repairs = repairs.OrderBy(r => r.StartDate);
                var activeRepairs = repairs.Where(c => !RepairProgressValue.Contains(c.Progress));
                var completeRepairs = repairs.Where(c => RepairProgressValue.Contains(c.Progress));
                RepairList = await activeRepairs.ToListAsync();
                CompleteRepairList = await completeRepairs.ToListAsync();
                

                var orders = from o in _context.Order
                             where o.ContactID == contact.ID
                             select o;
                orders = orders.OrderBy(o => o.StartDate);
                var activeOrders = orders.Where(o => !OrderProgressValue.Contains(o.Progress));
                var completeOrder = orders.Where(o => OrderProgressValue.Contains(o.Progress));
                OrderList = await activeOrders.ToListAsync();
                CompleteOrderList = await completeOrder.ToListAsync();

                var lessons = from l in _context.Lesson
                              where l.ContactID == contact.ID
                              select l;
                lessons = lessons.OrderBy(l => l.StartDate);
                var activeLessons = lessons.Where(l => l.Complete == true);
                var endedLessons = lessons.Where(l => l.Complete != true);
                LessonList = await activeLessons.ToListAsync();
                CompleteLessonList = await endedLessons.ToListAsync();
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

        public string RepairProgressValue = "[7] Collected";
        public string OrderProgressValue = "[5] Collected";
        public bool LessonComplete = true;

    }
}
