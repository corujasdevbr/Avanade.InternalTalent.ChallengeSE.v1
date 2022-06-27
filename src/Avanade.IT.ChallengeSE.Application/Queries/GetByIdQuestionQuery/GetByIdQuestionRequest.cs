using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Avanade.IT.ChallengeSE.Application.Queries.GetByIdQuestionQuery
{
    public class GetByIdQuestionRequest : IRequest<GetByIdQuestionResponse>
    {
        [Required(ErrorMessage = "Please enter a value Id")]
        public Guid Id { get; set; }
        public String[]? Includes { get; set; }
    }
}
