using Microsoft.EntityFrameworkCore;
using Nhom09.Models;

namespace Nhom09.Data
{
    public class shopsamsungContext : DbContext
    {
        public shopsamsungContext(DbContextOptions<shopsamsungContext> options) : base(options) { }

        public DbSet<admin> admins { get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<invoice> invoices { get; set; }
        public DbSet<invoice_detail> invoice_details { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<product_type> product_types { get; set; }

    }
}
