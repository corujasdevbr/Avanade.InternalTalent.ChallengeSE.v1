using AutoMapper;
using Avanade.IT.ChallengeSE.Application.Dtos;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace Avanade.IT.ChallengeSE.Application.Queries.GetByIdQuestionQuery
{
    public class GetByIdQuestionQuery : IRequestHandler<GetByIdQuestionRequest, GetByIdQuestionResponse>
    {
        #region Properties
        private IQuestionRepository _questionRepository { get; }
        private IMapper _mapper;

        #endregion

        #region Constructor

        public GetByIdQuestionQuery(IQuestionRepository questionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        #endregion

        public async Task<GetByIdQuestionResponse> Handle(GetByIdQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = new GetByIdQuestionResponse();

            try
            {
                var question = _questionRepository.GetById(request.Id, request.Includes);

                if (question == null)
                {
                    response.Message = "Nenhum Question encontrado";

                    response.Success = false;
                    response.StatusCode = (int)HttpStatusCode.NoContent;

                    return await Task.FromResult(response);
                }

                response.Data = _mapper.Map<QuestionDto>(question);
                response.StatusCode = (int)HttpStatusCode.OK;
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
