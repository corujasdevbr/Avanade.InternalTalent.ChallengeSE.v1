using Avanade.IT.ChallengeSE.CrossCuting.Common;

namespace Avanade.IT.ChallengeSE.Application.Commands.PostQuestionCommand
{
    public class PostQuestionResponse : GenericResult
    {
        public new Result Data { get; set; }
    }

    public class Result
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
