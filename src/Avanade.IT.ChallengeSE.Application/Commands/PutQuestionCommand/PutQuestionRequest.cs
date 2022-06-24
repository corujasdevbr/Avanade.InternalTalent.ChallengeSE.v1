using Avanade.IT.ChallengeSE.Domain.Entities;
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
        public Int32 Weight { get; set; }
        public Boolean Active { get; set; }

        public static implicit operator Question(PutQuestionRequest questionDto) =>
            new(
                questionDto.Id,
                questionDto.Title,
                questionDto.Points,
                questionDto.Weight,
                questionDto.Active,
                questionDto.Image);

    }
}
