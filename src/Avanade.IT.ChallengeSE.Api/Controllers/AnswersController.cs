using Avanade.IT.ChallengeSE.Application.Commands.PatchStatusAnswerCommand;
using Avanade.IT.ChallengeSE.Application.Commands.PostAnswerCommand;
using Avanade.IT.ChallengeSE.Application.Commands.PutAnswerCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avanade.IT.ChallengeSE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : MainController
    {
        private IMediator _mediator { get; set; }

        public AnswersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Add Answer.
        /// </summary>
        /// <param name="request">Data Answer</param>
        /// <returns>Object Answer</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Answers
        ///     {
        ///         {
        ///             "title": "string",
        ///             "image": "string",
        ///             "correct": bool,
        ///             "idQuestion": Guid,
        ///             "Active": bool
        ///         }
        ///     }
        /// </remarks>
        /// <response code="200">Return object Answer created</response>
        /// <response code="400">Case error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostAnswerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PostAnswerResponse))]
        public async Task<ActionResult> Post(
        [FromBody] PostAnswerRequest request,
        CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return CustomResponse(response);
        }

        /// <summary>
        /// UpdateAnswer.
        /// </summary>
        /// <param name="request">Data Answer</param>
        /// <returns>Answer updated</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Answers
        ///     {
        ///         {
        ///             "title": "string",
        ///             "image": "string",
        ///             "correct": bool,
        ///             "idQuestion": Guid,
        ///             "Active": bool
        ///         }
        ///     }
        /// </remarks>
        /// <response code="200">Return id and DateAltered Answer</response>
        /// <response code="400">Return Error</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PutAnswerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PutAnswerResponse))]
        public async Task<ActionResult> Put(Guid id,
        [FromBody] PutAnswerRequest request,
        CancellationToken cancellationToken)
        {
            request.Id = id;

            var response = await _mediator.Send(request, cancellationToken);

            return CustomResponse(response);
        }

        [HttpPatch("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PutAnswerResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PutAnswerResponse))]
        public async Task<ActionResult> PatchStatus(Guid id,
        CancellationToken cancellationToken)
        {

            PatchStatusAnswerRequest request = new PatchStatusAnswerRequest();
            request.Id = id;

            var response = await _mediator.Send(request, cancellationToken);

            return CustomResponse(response);
        }
    }
}
