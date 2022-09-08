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
    public class LanguageTechnologyConfiguration : IEntityTypeConfiguration<LanguageTechnology>
    {
        public void Configure(EntityTypeBuilder<LanguageTechnology> entity)
        {
            entity.ToTable("Languages").HasKey(p=>p.Id);
            entity.Property(p => p.Id).HasColumnName("Id");
            entity.Property(p => p.Name).HasColumnName("Name").IsRequired();
            entity.Property(p => p.LanguageId).HasColumnName("LanguageId").IsRequired();

            #region ForeingKey

            entity.HasOne(d => d.Language)
                            .WithMany(p => p.LanguageTechnologies)
                            .HasForeignKey(d => d.LanguageId)
                            .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Index

            entity.HasIndex(e => new { e.Name }, "UIX_Name").IsUnique();

            #endregion


        }

    }
}
