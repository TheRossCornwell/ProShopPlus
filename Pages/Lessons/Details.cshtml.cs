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
    public class DetailsModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public DetailsModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

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
    }
}
