using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.ValueObjects.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avanade.IT.ChallengeSE.Infra.Data.Configurations
{
    internal class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(p => p.Image).HasColumnType("VARCHAR(355)");
            builder.Property(p => p.Points).HasColumnType("INT").IsRequired();
            builder.Property(p => p.Active).HasColumnType("BIT").IsRequired();
            builder.Property(p => p.DateCreated).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.DateAltered).HasColumnType("DATETIME").IsRequired();

            builder
               .Property(x => x.Level)
               .HasColumnName("Level")
               .HasMaxLength(100)
               .HasColumnType<Level>("varchar(50)")
               .IsRequired()
               .HasConversion(
               s => s.ToString(),
               s => (Level)Enum.Parse(typeof(Level), s));
        }
    }
}
