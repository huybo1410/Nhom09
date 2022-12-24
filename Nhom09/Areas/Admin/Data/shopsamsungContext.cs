﻿using Microsoft.EntityFrameworkCore;
using Nhom09.Models;
using Nhom09.Data;

namespace Nhom09.Admin.Models.Data
{
    public class shopsamsungContext : DbContext
    {
        public shopsamsungContext(DbContextOptions<shopsamsungContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

    }
}
