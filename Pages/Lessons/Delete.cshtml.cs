using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Lessons
{
    public class DeleteModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public DeleteModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Lesson Lesson { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lesson == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FirstOrDefaultAsync(m => m.ID == id);

            if (lesson == null)
            {
                return NotFound();
            }
            else 
            {
                Lesson = lesson;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Lesson == null)
            {
                return NotFound();
            }
            var lesson = await _context.Lesson.FindAsync(id);

            if (lesson != null)
            {
                Lesson = lesson;
                _context.Lesson.Remove(Lesson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
