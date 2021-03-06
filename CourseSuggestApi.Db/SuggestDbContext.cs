﻿using Microsoft.EntityFrameworkCore;
using CourseSuggestApi.Db.Model;
using System;
using System.Collections.Generic;
namespace CourseSuggestApi.Db
{
    public class SuggestDbContext : DbContext
    {
        public SuggestDbContext(DbContextOptions<SuggestDbContext> options) : base(options)
        {
        }

        public DbSet<CourseSuggestion> CourseSuggestions { get; set; }
        public DbSet<AbilityLevel> AbilityLevels { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
   
    }
}
