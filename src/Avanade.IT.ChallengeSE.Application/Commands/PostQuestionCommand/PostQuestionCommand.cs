using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using MediatR;

namespace Avanade.IT.ChallengeSE.Application.Commands.PostQuestionCommand
{
    internal class PostQuestionCommand : IRequestHandler<PostQuestionRequest, PostQuestionResponse>
    {
        #region Properties
        private IQuestionRepository _questionRepository { get; }

        #endregion

        #region Contructor
        public PostQuestionCommand(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        #endregion

        public async Task<PostQuestionResponse> Handle(PostQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = new PostQuestionResponse();

            try
            {
                var question = _questionRepository.GetAll(x => x.Title == request.Title);

                if (question.Any())
                {
                    response.AddNotification("Title", "Question not registered because title has already been registered");
                    response.StatusCode = 500;
                    response.Message = "Error";
                    response.Success = false;

                    return await Task.FromResult(response);
                }

                var questionResult = _questionRepository.Add(request);

                response.StatusCode = 201;
                response.Message = "Question registered";
                response.Data = new Result() { Id = questionResult.Id, DateCreated = questionResult.DateCreated };
                response.Success = true;

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
