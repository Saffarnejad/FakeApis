﻿using FakeApis.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeApis.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
