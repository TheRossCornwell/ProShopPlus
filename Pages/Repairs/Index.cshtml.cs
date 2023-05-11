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
    public class IndexModel : PageModel
    {
        private readonly ProShopPlus.Data.ProShopPlusContext _context;

        public IndexModel(ProShopPlus.Data.ProShopPlusContext context)
        {
            _context = context;
        }

        public IList<Repair> Repair { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Repair != null)
            {
                Repair = await _context.Repair
                .Include(r => r.Contact).ToListAsync();
            }
        }
    }
}
