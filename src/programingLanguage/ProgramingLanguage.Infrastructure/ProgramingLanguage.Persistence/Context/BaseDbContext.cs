﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgramingLanguage.Domain.Configurations;
using ProgramingLanguage.Domain.Entities;


namespace ProgramingLanguage.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            SeedLanguage(modelBuilder);
           
        }
        #region Seed

        private void SeedLanguage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                    new Language(id : 1, name : "C#"),
                    new Language(id : 2, name : "Java")
                );
        }

        #endregion
    }
}