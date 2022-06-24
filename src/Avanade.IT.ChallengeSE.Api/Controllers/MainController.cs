using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Avanade.IT.ChallengeSE.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object? result = null)
        {
            if (IsOperationValid())
            {

                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(Notifiable<Notification> result)
        {
            if (result.Notifications.Count == 0)
            {
                return Ok(result);
            }

            foreach (var error in result.Notifications)
            {
                AddError(error.Message);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected bool IsOperationValid()
        {
            return !Errors.Any();
        }

        protected void AddError(string erro)
        {
            Errors.Add(erro);
        }

        protected void ClearErrors()
        {
            Errors.Clear();
        }

    }
}
