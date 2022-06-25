using AutoMapper;
using Avanade.IT.ChallengeSE.Application.Dtos;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using Canducci.Pagination;
using MediatR;
using System.Net;

namespace Avanade.IT.ChallengeSE.Application.Queries.GetAllQuestionQuery
{
    public class GetAllQuestionQuery : IRequestHandler<GetAllQuestionRequest, GetAllQuestionResponse>
    {
        #region Properties
        private IQuestionRepository _questionRepository { get; }
        private IMapper _mapper;

        #endregion

        #region Contructor
        public GetAllQuestionQuery(IQuestionRepository questionRepository,IMapper mapper)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        #endregion

        public async Task<GetAllQuestionResponse> Handle(GetAllQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllQuestionResponse();

            try
            {
                var questions = _questionRepository.GetAll(null, request.Includes);

                if (!string.IsNullOrEmpty(request.Title))
                    questions = questions.Where(x => x.Title.ToLower().Contains(request.Title.ToLower())).AsQueryable();

                if (request.Status != null)
                    questions = questions.Where(x => x.Active == request.Status).AsQueryable();

                var questionsDistinct = questions.GroupBy(q => q.Title).Select(x => x.First()).ToList();

                var questionsPaginacao = _mapper.Map<IEnumerable<QuestionDto>>(questionsDistinct.Distinct()).ToPaginatedRest(request.Page, request.Quantity);

                response.Data = questionsPaginacao;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Success";

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.AddNotification("Error", ex.Message);
                response.StatusCode = 500;
                response.Message = "An error has occurred";
                response.Success = false;

                return await Task.FromResult(response);
            }
        }
    }
}
