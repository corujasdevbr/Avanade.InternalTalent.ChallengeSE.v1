using AutoMapper;
using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using MediatR;

namespace Avanade.IT.ChallengeSE.Application.Commands.PutQuestionCommand
{
    public class PutQuestionCommand : IRequestHandler<PutQuestionRequest, PutQuestionResponse>
    {
        #region Properties
        private IQuestionRepository _questionRepository { get; }
        private IMapper _mapper { get; }
        #endregion

        #region Contructor
        public PutQuestionCommand(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<PutQuestionResponse> Handle(PutQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = new PutQuestionResponse();

            try
            {
                var question = _questionRepository.GetById(request.Id);

                if (question == null)
                {
                    response.AddNotification("Question", "Question Not Found");
                    response.StatusCode = 204;
                    response.Message = "An error has occurred";
                    response.Success = false;

                    return await Task.FromResult(response);
                }

                var questionResult = _questionRepository.Update(_mapper.Map<Question>(request));


                response.StatusCode = 200;
                response.Message = "Question Altered";
                response.Data = new Result() { Id = questionResult.Id, DateAltered = questionResult.DateAltered };
                response.Success = true;

                return await Task.FromResult(response);
            }
            catch (System.Exception ex)
            {
                response.AddNotification("Error", ex.Message);
                response.StatusCode = 500;
                response.Message = "An error has occurred";
                response.Success = false;

                return await Task.FromResult(response);
            }
        }
        #endregion
    }
}
