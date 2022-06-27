using Avanade.IT.ChallengeSE.CrossCuting.Common;

namespace Avanade.IT.ChallengeSE.Application.Commands.PutAnswerCommand
{
    public class PutAnswerResponse : GenericResult
    {
        public new Result Data { get; set; }
    }

    public class Result
    {
        public Guid Id { get; set; }
        public DateTime DateAltered { get; set; }
    }
}
