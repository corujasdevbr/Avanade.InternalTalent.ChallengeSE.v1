using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using MediatR;

namespace Avanade.IT.ChallengeSE.Application.Commands.PatchStatusQuestionCommand
{
    public class PatchStatusQuestionCommand : IRequestHandler<PatchStatusQuestionRequest, PatchStatusQuestionResponse>
    {
        #region Properties
        private IQuestionRepository _questionRepository { get; }

        #endregion

        #region Contructor
        public PatchStatusQuestionCommand(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<PatchStatusQuestionResponse> Handle(PatchStatusQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = new PatchStatusQuestionResponse();

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


                question.ChangeStatus();

                var questionResult = _questionRepository.Update(question);


                response.StatusCode = 200;
                response.Message = "Question Altered";
                response.Data = new Result() { Id = questionResult.Id, DateAltered = questionResult.DateAltered };
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
        #endregion
    }
}
