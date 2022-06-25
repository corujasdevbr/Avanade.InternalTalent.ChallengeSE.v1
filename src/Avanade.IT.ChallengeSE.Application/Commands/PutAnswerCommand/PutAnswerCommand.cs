using AutoMapper;
using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.IT.ChallengeSE.Application.Commands.PutAnswerCommand
{
    public class PutAnswerCommand : IRequestHandler<PutAnswerRequest, PutAnswerResponse>
    {
        #region Properties
        private IAnswerRepository _answerRepository { get; }
        private IMapper _mapper { get; }

        #endregion

        #region Contructor
        public PutAnswerCommand(IAnswerRepository AnswerRepository,IMapper mapper)
        {
            _answerRepository = AnswerRepository;
            _mapper = mapper;
        }

        public async Task<PutAnswerResponse> Handle(PutAnswerRequest request, CancellationToken cancellationToken)
        {
            var response = new PutAnswerResponse();

            try
            {

                var answer = _answerRepository.GetById(request.Id);

                if (answer == null)
                {
                    response.AddNotification("Answer", "Answer Not Found");
                    response.StatusCode = 204;
                    response.Message = "An error has occurred";
                    response.Success = false;

                    return await Task.FromResult(response);
                }

                var answerResult = _answerRepository.Update(_mapper.Map<Answer>(request));

                response.StatusCode = 200;
                response.Message = "Answer Altered";
                response.Data = new Result() { Id = answerResult.Id, DateAltered = answerResult.DateAltered };
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
