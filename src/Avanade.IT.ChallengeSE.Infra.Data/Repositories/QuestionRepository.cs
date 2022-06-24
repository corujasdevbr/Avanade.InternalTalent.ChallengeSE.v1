using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using Avanade.IT.ChallengeSE.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Avanade.IT.ChallengeSE.Infra.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {

        private readonly DbTcContext _dbTcContext;
        private readonly ILogger _logger;

        public QuestionRepository(DbTcContext dbTcContext, ILogger<QuestionRepository> logger)
        {
            _dbTcContext = dbTcContext;
            _logger = logger;
        }


        #region Read
        public IEnumerable<Question> GetAll(Func<Question, bool>? expr = null, string[]? includes = null)
        {
            _logger.LogInformation("Get All Talent Community");
            if (expr != null) _logger.LogInformation($"Exp {expr}");
            if (includes != null) _logger.LogInformation($"Includes {includes}");

            var query = _dbTcContext.Questions.AsNoTracking().AsQueryable();

            if (includes == null)
                return (expr == null) ? query.AsQueryable() : query.Where(expr).AsQueryable();


            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return (expr == null) ? query.AsQueryable() : query.Where(expr).AsQueryable();
        }

        public Question? GetById(Guid id, string[]? includes = null)
        {
            _logger.LogInformation($"Get Talent Community Id - {id}");
            if (includes != null) _logger.LogInformation($"Includes {includes}");

            var query = _dbTcContext.Questions.AsNoTracking().AsQueryable();

            if (includes == null) return query.FirstOrDefault(x => x.Id == id);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(x => x.Id == id);
        }
        #endregion


        #region Write
        public Question Add(Question Question)
        {
            _logger.LogInformation("Add Talent Community");
            _dbTcContext.Questions.Add(Question);
            _dbTcContext.SaveChanges();
            _logger.LogInformation("Talent Community", Question);

            return Question;
        }

        public Question Update(Question Question)
        {
            _logger.LogInformation("Update Talent Community");
            _dbTcContext.Questions.Add(Question).State = EntityState.Modified;
            _dbTcContext.SaveChanges();
            _logger.LogInformation("Talent Community", Question);

            return Question;
        }
        
        #endregion
    }
}
