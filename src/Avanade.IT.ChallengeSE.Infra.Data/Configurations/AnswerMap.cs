using Avanade.IT.ChallengeSE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avanade.IT.ChallengeSE.Infra.Data.Configurations
{
    internal class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(p => p.Image).HasColumnType("VARCHAR(355)");
            builder.Property(p => p.Correct).HasColumnType("BIT").IsRequired();
            builder.Property(p => p.Active).HasColumnType("BIT").IsRequired();
            builder.Property(p => p.DateCreated).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.DateAltered).HasColumnType("DATETIME").IsRequired();

            builder.HasOne<Question>(s => s.Question)
                   .WithMany(g => g.Answers)
                   .HasForeignKey(s => s.IdQuestion);
        }
    }
}
