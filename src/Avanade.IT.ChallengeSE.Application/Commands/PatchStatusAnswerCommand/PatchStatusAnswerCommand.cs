using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using MediatR;

namespace Avanade.IT.ChallengeSE.Application.Commands.PatchStatusAnswerCommand
{
    internal class PatchStatusAnswerCommand : IRequestHandler<PatchStatusAnswerRequest, PatchStatusAnswerResponse>
    {
        #region Properties
        private IAnswerRepository _answerRepository { get; }

        #endregion

        #region Contructor
        public PatchStatusAnswerCommand(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<PatchStatusAnswerResponse> Handle(PatchStatusAnswerRequest request, CancellationToken cancellationToken)
        {
            var response = new PatchStatusAnswerResponse();

            try
            {

                var Answer = _answerRepository.GetById(request.Id);

                if (Answer == null)
                {
                    response.AddNotification("Answer", "Answer Not Found");
                    response.StatusCode = 204;
                    response.Message = "An error has occurred";
                    response.Success = false;

                    return await Task.FromResult(response);
                }

                Answer.ChangeStatus();

                var AnswerResult = _answerRepository.Update(Answer);


                response.StatusCode = 200;
                response.Message = "Answer Altered";
                response.Data = new Result() { Id = AnswerResult.Id, DateAltered = AnswerResult.DateAltered };
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
