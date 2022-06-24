using MediatR;
using System.Text.Json.Serialization;

namespace Avanade.IT.ChallengeSE.Application.Commands.PatchStatusQuestionCommand
{
    public class PatchStatusQuestionRequest : IRequest<PatchStatusQuestionResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

    }
}
