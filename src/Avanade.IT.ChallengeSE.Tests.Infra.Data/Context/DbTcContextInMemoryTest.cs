using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.ValueObjects.Enumerators;
using Avanade.IT.ChallengeSE.Infra.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Avanade.IT.ChallengeSE.Tests.Infra.Data.Context
{
    public class DbTcContextInMemoryTest : DbContext
    {
        private DbContextOptions<DbTcContext> dbContextOptions;

        private readonly Faker<Question> _fakerQuestion;

        public readonly DbTcContext _context;

        public DbTcContextInMemoryTest()
        {
            var dbName = "Data Source=:memory:";
            dbContextOptions = new DbContextOptionsBuilder<DbTcContext>()
                .UseSqlite(@"Data Source=questions.db")
                .EnableSensitiveDataLogging()
                .Options;


            _context = new DbTcContext(dbContextOptions);

            _fakerQuestion = new Faker<Question>("pt_BR");

            CarregaDados();
        }

        private void CarregaDados()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var testQuestion = _fakerQuestion
                                        .StrictMode(false)
                                        .RuleFor(p => p.Title, u => u.Lorem.Sentence())
                                        .RuleFor(p => p.Image, u => u.Image.People().ToLower())
                                        .RuleFor(p => p.Points, u => u.Random.Number(1, 5))
                                        .RuleFor(p => p.Level, u => (Level)u.Random.Number(1, 3));

            _context.Questions.Add(testQuestion.Generate());
            _context.Questions.Add(testQuestion.Generate());


            _context.SaveChanges();
        }
    }
}
