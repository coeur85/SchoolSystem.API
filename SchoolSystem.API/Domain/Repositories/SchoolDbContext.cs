﻿using Microsoft.EntityFrameworkCore;
using SchoolSystem.API.Domain.Models.Students;

namespace SchoolSystem.API.Domain.Repositories
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(x=> x.Id).ValueGeneratedOnAdd();
           

            modelBuilder.Entity<Student>().HasData(
                 new Student { Id = 1 , Name = "ahmed" },
                 new Student { Id = 2, Name= "Jhon" },
                 new Student { Id = 3, Name = "Smith" }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}
