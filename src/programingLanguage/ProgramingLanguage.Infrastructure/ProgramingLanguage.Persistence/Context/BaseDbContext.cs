using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProgramingLanguage.Domain.Configurations;
using ProgramingLanguage.Domain.Entities;


namespace ProgramingLanguage.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            SeedLanguage(modelBuilder);
            SeedLanguageTechnology(modelBuilder);
           
        }
        #region Seed
       

        private void SeedLanguage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                    new Language(id : 1, name : "C#"),
                    new Language(id : 2, name : "Java")
                );
        }

         private void SeedLanguageTechnology(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageTechnology>().HasData(
                    new LanguageTechnology(id : 1, name : "Asp.Net",languageId:1),
                    new LanguageTechnology(id : 2, name : "Spring",languageId:2)
                );
        }

        #endregion
    }
}
