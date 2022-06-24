using Avanade.IT.ChallengeSE.CrossCuting.Common;

namespace Avanade.IT.ChallengeSE.Application.Commands.PatchStatusQuestionCommand
{
    public class PatchStatusQuestionResponse : GenericResult
    {
        public new Result Data { get; set; }
    }

    public class Result
    {
        public Guid Id { get; set; }
        public DateTime DateAltered { get; set; }
    }
}
