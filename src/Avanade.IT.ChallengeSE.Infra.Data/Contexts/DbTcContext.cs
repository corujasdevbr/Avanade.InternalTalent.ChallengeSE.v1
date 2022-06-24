using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Infra.Data.Configurations;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Avanade.IT.ChallengeSE.Infra.Data.Contexts
{
    public class DbTcContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbTcContext()
        {

        }

        public DbTcContext(DbContextOptions<DbTcContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=sqlserver;Initial Catalog=DB_QuesAns_Dev;User ID=sa;Password=<YourStrong@Passw0rd>");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new QuestionMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateCreated") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DateCreated").CurrentValue = DateTime.Now;
                        entry.Property("DateAltered").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DateCreated").IsModified = false;
                        entry.Property("DateAltered").CurrentValue = DateTime.Now;
                    }
                }

                return base.SaveChanges();
            }
            catch (Exception e)
            {
                Exception exception = new Exception(e.Message);
                throw exception;
            }
        }
    }
}
