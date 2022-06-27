using Avanade.IT.ChallengeSE.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Avanade.IT.ChallengeSE.Application.Commands.PostAnswerCommand
{
    public class PostAnswerRequest : IRequest<PostAnswerResponse>
    {
        [Required(ErrorMessage = "Please enter a value Title")]
        public String Title { get; set; }
        public String? Image { get; set; }
        public Boolean Correct { get; set; }
        public Guid IdQuestion { get; set; }
        public Boolean Active { get; set; }

        public static implicit operator Answer(PostAnswerRequest answerDto) =>
            new(
                answerDto.Title,
                answerDto.IdQuestion,
                answerDto.Correct,
                answerDto.Active,
                answerDto.Image);
    }
}
