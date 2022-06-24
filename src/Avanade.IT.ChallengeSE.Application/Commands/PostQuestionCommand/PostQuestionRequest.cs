using Avanade.IT.ChallengeSE.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Avanade.IT.ChallengeSE.Application.Commands.PostQuestionCommand
{
    public class PostQuestionRequest : IRequest<PostQuestionResponse>
    {
        [Required(ErrorMessage = "Please enter a value Title")]
        public String Title { get; set; }
        public String? Image { get; set; }

        [Range(1, 10, ErrorMessage = "Please enter a value bigger than {1}")]
        public Int32 Points { get; set; } = 1;

        [Range(1, 3, ErrorMessage = "Please enter a value bigger than {1}")]
        public Int32 Weight { get; set; } = 1; 
        public Boolean Active { get; set; }

        public static implicit operator Question(PostQuestionRequest questionDto) =>
            new(
                questionDto.Title,
                questionDto.Points,
                questionDto.Weight,
                questionDto.Active,
                questionDto.Image);

    }
}
