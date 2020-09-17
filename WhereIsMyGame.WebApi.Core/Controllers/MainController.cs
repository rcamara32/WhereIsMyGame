using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WhereIsMyGame.Core.Communication;

namespace WhereIsMyGame.WebApi.Core.Controllers
{

    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
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
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AddError(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult response)
        {
            ResponseHasErrors(response);

            return CustomResponse();
        }

        protected bool ResponseHasErrors(ResponseResult response)
        {
            if (response == null || !response.Errors.Messages.Any()) return false;

            foreach (var msg in response.Errors.Messages)
            {
                AddError(msg);
            }

            return true;
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