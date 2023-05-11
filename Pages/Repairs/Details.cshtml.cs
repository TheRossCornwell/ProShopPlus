using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProShopPlus.Data;
using ProShopPlus.Models;

namespace ProShopPlus.Pages.Repairs
{
    public class DetailsModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public DetailsModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

      public Repair Repair { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Repair == null)
            {
                return NotFound();
            }

            var repair = await _context.Repair.FirstOrDefaultAsync(m => m.ID == id);
            if (repair == null)
            {
                return NotFound();
            }
            else 
            {
                Repair = repair;
            }
            return Page();
        }
    }
}
