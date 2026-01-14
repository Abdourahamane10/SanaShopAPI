using Microsoft.EntityFrameworkCore;
using SanaShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Infrastructure.Database
{
    public class SanaShopDbContext : DbContext
    {
        public SanaShopDbContext(DbContextOptions<SanaShopDbContext> options) : base(options)
        {
        }

        public DbSet<ParametreGeneral> ParametresGeneraux => Set<ParametreGeneral>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
