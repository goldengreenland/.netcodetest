using Microsoft.EntityFrameworkCore;
using System;
using Pcms.Core.Entities.Entities;

namespace Pcms.Core.Repository
{
    public class PcmsDbContext : DbContext
    {
        public PcmsDbContext(DbContextOptions<PcmsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PromoCode> PromoCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
