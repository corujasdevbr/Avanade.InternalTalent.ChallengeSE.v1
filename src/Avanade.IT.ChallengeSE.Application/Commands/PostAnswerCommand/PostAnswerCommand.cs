using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using MediatR;

namespace Avanade.IT.ChallengeSE.Application.Commands.PostAnswerCommand
{
    internal class PostAnswerCommand : IRequestHandler<PostAnswerRequest, PostAnswerResponse>
    {
        #region Properties
        private IAnswerRepository _answerRepository { get; }
        private IQuestionRepository _questionRepository { get; }

        #endregion

        #region Contructor
        public PostAnswerCommand(IAnswerRepository AnswerRepository, IQuestionRepository questionRepository)
        {
            _answerRepository = AnswerRepository;
            _questionRepository = questionRepository;
        }
        #endregion

        public async Task<PostAnswerResponse> Handle(PostAnswerRequest request, CancellationToken cancellationToken)
        {
            var response = new PostAnswerResponse();

            try
            {
                #region business rules
                var question = _questionRepository.GetAll(x => x.Id == request.IdQuestion);

                if (question == null)
                {
                    response.AddNotification("Question", "Question not found");
                    response.StatusCode = 500;
                    response.Message = "Error";
                    response.Success = false;

                    return await Task.FromResult(response);
                }

                var answer = _answerRepository.GetAll(x => x.Title == request.Title && x.IdQuestion == request.IdQuestion);

                if (answer.Any())
                {
                    response.AddNotification("Title", "Answer not registered because title has already been registered by Question");
                    response.StatusCode = 500;
                    response.Message = "Error";
                    response.Success = false;

                    return await Task.FromResult(response);
                }
                #endregion

                var AnswerResult = _answerRepository.Add(request);

                response.StatusCode = 201;
                response.Message = "Answer registered";
                response.Data = new Result() { Id = AnswerResult.Id, DateCreated = AnswerResult.DateCreated };
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
