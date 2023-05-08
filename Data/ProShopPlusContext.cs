using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProShopPlus.Models;

namespace ProShopPlus.Data
{
    public class ProShopPlusContext : DbContext
    {
        public ProShopPlusContext (DbContextOptions<ProShopPlusContext> options)
            : base(options)
        {
        }

        public DbSet<ProShopPlus.Models.Contact> Contact { get; set; } = default!;
    }
}
