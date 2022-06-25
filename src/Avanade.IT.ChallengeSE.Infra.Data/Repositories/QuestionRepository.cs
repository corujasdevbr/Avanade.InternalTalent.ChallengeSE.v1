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
        public IEnumerable<Question> GetAll(Func<Question, Boolean>? expr = null, String[]? includes = null)
        {
            _logger.LogInformation("Get All Question");
            if (expr != null) _logger.LogInformation($"Exp {expr}");
            if (includes != null) _logger.LogInformation($"Includes {includes}");

            var query = _dbTcContext.Questions.AsNoTracking().AsQueryable();

            if (includes == null)
                return (expr == null) ? query.AsQueryable() : query.Where(expr).AsQueryable();


            foreach (var include in includes)
            {
                query = query.Include(include).AsNoTracking();
            }

            return (expr == null) ? query.AsQueryable() : query.Where(expr).AsQueryable();
        }

        public Question? GetById(Guid id, String[]? includes = null)
        {
            _logger.LogInformation($"Get Question Id - {id}");
            if (includes != null) _logger.LogInformation($"Includes {includes}");

            var query = _dbTcContext.Questions.AsNoTracking().AsQueryable();

            if (includes == null) return query.FirstOrDefault(x => x.Id == id);

            foreach (var include in includes)
            {
                query = query.Include(include).AsNoTracking();
            }
            return query.FirstOrDefault(x => x.Id == id);
        }
        #endregion


        #region Write
        public Question Add(Question question)
        {
            _logger.LogInformation("Add Question");
            _dbTcContext.Questions.Add(question);
            _dbTcContext.SaveChanges();
            _logger.LogInformation("Talent Community", question);

            return question;
        }

        public Question Update(Question question)
        {
            _logger.LogInformation("Update Question");
            _dbTcContext.Questions.Add(question).State = EntityState.Modified;
            _dbTcContext.SaveChanges();
            _logger.LogInformation("Question", question);

            return question;
        }
        
        #endregion
    }
}
