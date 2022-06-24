using MediatR;

namespace Avanade.IT.ChallengeSE.Application.Queries.GetAllQuestionQuery
{
    public class GetAllQuestionRequest : IRequest<GetAllQuestionResponse>
    {
        public int Page { get; set; } = 1;
        public int Quantity { get; set; } = 10;
        public string? Title { get; set; }
        public Boolean? Status { get; set; }
    }
}
