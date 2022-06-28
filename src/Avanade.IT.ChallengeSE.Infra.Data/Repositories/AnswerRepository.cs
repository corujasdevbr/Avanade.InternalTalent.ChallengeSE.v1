using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using Avanade.IT.ChallengeSE.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Avanade.IT.ChallengeSE.Infra.Data.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {

        private readonly DbTcContext _dbTcContext;
        private readonly ILogger _logger;

        public AnswerRepository(DbTcContext dbTcContext, ILogger<AnswerRepository> logger)
        {
            _dbTcContext = dbTcContext;
            _logger = logger;
        }

        #region Write
        public Answer Add(Answer answer)
        {
            _logger.LogInformation("Add Answer");
            _dbTcContext.Answers.Add(answer);
            _dbTcContext.SaveChanges();
            _logger.LogInformation("Answer", answer);

            return answer;
        }

        public Answer Update(Answer answer)
        {
            _logger.LogInformation("Update Answer");
            _dbTcContext.Answers.Add(answer).State = EntityState.Modified;
            _dbTcContext.SaveChanges();
            _logger.LogInformation("Question", answer);

            return answer;
        }
        #endregion

        #region Read
        public IEnumerable<Answer> GetAll(Func<Answer, Boolean>? expr = null, String[]? includes = null)
        {
            _logger.LogInformation("Get All Answer");
            if (expr != null) _logger.LogInformation($"Exp {expr}");
            if (includes != null) _logger.LogInformation($"Includes {includes}");

            var query = _dbTcContext.Answers.AsNoTracking().AsQueryable();

            if (includes == null)
                return (expr == null) ? query.AsQueryable() : query.Where(expr).AsQueryable();


            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return (expr == null) ? query.AsQueryable() : query.Where(expr).AsQueryable();
        }

        public Answer? GetById(Guid id, String[]? includes = null)
        {
            _logger.LogInformation($"Get Answer Id - {id}");
            if (includes != null) _logger.LogInformation($"Includes {includes}");

            var query = _dbTcContext.Answers.AsNoTracking().AsQueryable();

            if (includes == null) return query.FirstOrDefault(x => x.Id == id);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(x => x.Id == id);
        }
        #endregion


    }
}
