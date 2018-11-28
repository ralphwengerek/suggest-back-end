using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CourseSuggestApi.Db
{
    public class SuggestDbContextFactory : IDesignTimeDbContextFactory<SuggestDbContext>
    {
        public SuggestDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SuggestDbContext>();

            builder.UseSqlite("Filename =../CourseSuggestApi/CourseSuggest.db");

            return new SuggestDbContext(builder.Options);
        }
    }
}