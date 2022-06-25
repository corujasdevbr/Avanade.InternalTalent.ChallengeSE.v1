using Avanade.IT.ChallengeSE.Domain.Entities;

namespace Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        #region Read
        /// <summary>
        /// Get All Talent Community
        /// </summary>
        /// <returns>All Talent Community</returns>
        IEnumerable<Answer> GetAll(Func<Answer, Boolean>? expr = null, String[]? includes = null);


        /// <summary>
        /// Get Talent Community by Id
        /// </summary>
        /// <param name="id">Id Talent Community</param>
        /// <returns>If found returns Talent Community</returns>
        Answer? GetById(Guid id, String[]? includes = null);
        #endregion


        #region Write
        /// <summary>
        /// Add new Talent Community
        /// </summary>
        /// <param name="Answer">Data Talent Community</param>
        /// <returns>Talent Community Created</returns>
        Answer Add(Answer Answer);

        /// <summary>
        /// Update Talent Community
        /// </summary>
        /// <param name="Answer">Data Talent Community</param>
        /// <returns>Object Talent Comunity</returns>
        Answer Update(Answer Answer);

        #endregion
    }
}
