using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlAccess.Models;

namespace ControlAccess.Data
{
    public class ControlAccessContext : DbContext
    {
        public ControlAccessContext (DbContextOptions<ControlAccessContext> options)
            : base(options)
        {
        }

        public DbSet<ControlAccess.Models.Residencial> Residencial { get; set; } = default!;
    }
}
