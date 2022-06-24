using Avanade.IT.ChallengeSE.Domain.Entities;

namespace Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories
{
    public interface IQuestionRepository
    {

        #region Read
        /// <summary>
        /// Get All Talent Community
        /// </summary>
        /// <returns>All Talent Community</returns>
        IEnumerable<Question> GetAll(Func<Question, bool>? expr = null, string[]? includes = null);


        /// <summary>
        /// Get Talent Community by Id
        /// </summary>
        /// <param name="id">Id Talent Community</param>
        /// <returns>If found returns Talent Community</returns>
        Question? GetById(Guid id, string[]? includes = null);
        #endregion


        #region Write
        /// <summary>
        /// Add new Talent Community
        /// </summary>
        /// <param name="Question">Data Talent Community</param>
        /// <returns>Talent Community Created</returns>
        Question Add(Question Question);

        /// <summary>
        /// Update Talent Community
        /// </summary>
        /// <param name="Question">Data Talent Community</param>
        /// <returns>Object Talent Comunity</returns>
        Question Update(Question Question);
        
        #endregion
    }
}
