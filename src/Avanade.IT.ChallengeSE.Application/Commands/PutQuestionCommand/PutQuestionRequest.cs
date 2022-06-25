using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.ValueObjects.Enumerators;
using MediatR;
using System.Text.Json.Serialization;

namespace Avanade.IT.ChallengeSE.Application.Commands.PutQuestionCommand
{
    public class PutQuestionRequest : IRequest<PutQuestionResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String? Image { get; set; }
        public Int32 Points { get; set; }
        public Level Level { get; set; }
        public Boolean Active { get; set; }
    }
}
