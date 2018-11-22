using Microsoft.EntityFrameworkCore;
using CourseSuggestApi.Data.Model;
using System;
using System.Collections.Generic;
namespace CourseSuggestApi.Data
{
    public class SuggestDbContext : DbContext
    {
        public SuggestDbContext(DbContextOptions<SuggestDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
   
    }
}
