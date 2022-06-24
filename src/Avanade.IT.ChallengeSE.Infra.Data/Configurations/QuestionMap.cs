using Avanade.IT.ChallengeSE.Domain.Entities;
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
            builder.Property(p => p.Weight).HasColumnType("INT").IsRequired();
            builder.Property(p => p.Active).HasColumnType("BIT").IsRequired();
            builder.Property(p => p.DateCreated).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.DateAltered).HasColumnType("DATETIME").IsRequired();
        }
    }
}
