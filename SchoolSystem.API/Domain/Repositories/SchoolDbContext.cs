﻿using Microsoft.EntityFrameworkCore;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Repositories
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(x => x.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}
