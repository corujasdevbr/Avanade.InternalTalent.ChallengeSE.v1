using MediatR;

namespace Avanade.IT.ChallengeSE.Application.Commands.PatchStatusAnswerCommand
{
    public class PatchStatusAnswerRequest : IRequest<PatchStatusAnswerResponse>
    {
        public Guid Id { get; set; }
    }
}
