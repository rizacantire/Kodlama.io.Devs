using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguage.Domain.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.ToTable("Languages").HasKey(p=>p.Id);
            entity.Property(p => p.Id).HasColumnName("Id");
            entity.Property(p => p.Name).HasColumnName("Name").IsRequired();

            #region ForeingKey



            #endregion

            #region Index

            entity.HasIndex(e => new { e.Name }, "UIX_Name").IsUnique();

            #endregion


        }

    }
}
