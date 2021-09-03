using Microsoft.EntityFrameworkCore;
using System;
using Estore.Core.Entities.Entities;

namespace Estore.Core.Repository
{
    public class EStoreDbContext : DbContext
    {
        public EStoreDbContext(DbContextOptions<EStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Voucher> EVoucher { get; set; }
        public virtual DbSet<BuyType> BuyType { get; set; }
        public virtual DbSet<CouponType> CouponType { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<PaymentMethodDiscount> PaymentMethodDiscount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
