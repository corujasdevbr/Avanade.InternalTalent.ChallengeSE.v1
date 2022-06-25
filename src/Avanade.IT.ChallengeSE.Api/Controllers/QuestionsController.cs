using Avanade.IT.ChallengeSE.Application.Commands.PatchStatusQuestionCommand;
using Avanade.IT.ChallengeSE.Application.Commands.PostQuestionCommand;
using Avanade.IT.ChallengeSE.Application.Commands.PutQuestionCommand;
using Avanade.IT.ChallengeSE.Application.Queries.GetAllQuestionQuery;
using Avanade.IT.ChallengeSE.Application.Queries.GetByIdQuestionQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avanade.IT.ChallengeSE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : MainController
    {
        private IMediator _mediator { get; set; }

        public QuestionsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Add Question.
        /// </summary>
        /// <param name="request">Data Question</param>
        /// <returns>Object Question</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Questions
        ///     {
        ///         {
        ///             "title": "string",
        ///             "image": "string",
        ///             "Points": int,
        ///             "Weight": int,
        ///             "Active": bool
        ///         }
        ///     }
        /// </remarks>
        /// <response code="200">Return object question created</response>
        /// <response code="400">Case error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostQuestionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PostQuestionResponse))]
        public async Task<ActionResult> Post(
        [FromBody] PostQuestionRequest request,
        CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return CustomResponse(response);
        }

        /// <summary>
        /// Update Question.
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
        ///             "Points": int,
        ///             "Weight": int,
        ///             "Active": bool
        ///         }
        ///     }
        /// </remarks>
        /// <response code="200">Return id and DateAltered Question</response>
        /// <response code="400">Return Error</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PutQuestionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PutQuestionResponse))]
        public async Task<ActionResult> Put(Guid id,
        [FromBody] PutQuestionRequest request,
        CancellationToken cancellationToken)
        {
            request.Id = id;

            var response = await _mediator.Send(request, cancellationToken);

            return CustomResponse(response);
        }


        [HttpPatch("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PutQuestionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PutQuestionResponse))]
        public async Task<ActionResult> PatchStatus(Guid id,
        CancellationToken cancellationToken)
        {

            PatchStatusQuestionRequest request = new PatchStatusQuestionRequest();
            request.Id = id;

            var response = await _mediator.Send(request, cancellationToken);

            return CustomResponse(response);
        }


        /// <summary>
        /// Get all Question can filter by name and status
        /// </summary>
        /// <returns>Dados do Profissional</returns>
        /// <response code="200">Retorna uma lista profissionais</response>
        /// <response code="400">Caso ocorra algum erro</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllQuestionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetAllQuestionResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQuestionRequest request,
          CancellationToken cancelationToken
        )
        {
            var result = await _mediator.Send(request, cancelationToken);

            return CustomResponse(result);
        }

        /// <summary>
        /// Get Question by id.
        /// </summary>
        /// <param name="id">Id Question</param>
        /// <returns>Data Question</returns>
        /// <response code="200">Return object Question</response>
        /// <response code="400">Return Error</response>
        [HttpGet("byId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByIdQuestionResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GetByIdQuestionResponse))]
        public async Task<ActionResult> GetById([FromQuery] GetByIdQuestionRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return CustomResponse(response);
        }
    }
}
