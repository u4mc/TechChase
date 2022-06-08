#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechChase.Models;

namespace TechChase.Data
{
    public class TechChaseContext : DbContext
    {
        public TechChaseContext (DbContextOptions<TechChaseContext> options)
            : base(options)
        {
        }

        public DbSet<TechChase.Models.Tech> Tech { get; set; }
    }
}
