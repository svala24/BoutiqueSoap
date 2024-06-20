using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoutiqueSoap.Models;

namespace BoutiqueSoap.Data
{
    public class BoutiqueSoapContext : DbContext
    {
        public BoutiqueSoapContext (DbContextOptions<BoutiqueSoapContext> options)
            : base(options)
        {
        }

        public DbSet<BoutiqueSoap.Models.Soap> Soap { get; set; } = default!;
    }
}
