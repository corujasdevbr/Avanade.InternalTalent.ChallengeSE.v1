using MediatR;
using System.Text.Json.Serialization;

namespace Avanade.IT.ChallengeSE.Application.Commands.PutAnswerCommand
{
    public class PutAnswerRequest : IRequest<PutAnswerResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String? Image { get; set; }
        public Boolean Correct { get; set; }
        public Guid IdQuestion { get; set; }
    }
}
