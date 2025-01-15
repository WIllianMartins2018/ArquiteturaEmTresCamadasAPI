using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected bool OperacaoValida()
        {
            return true;
        }

        protected ActionResult CustomeReponse(object result = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(result);
            }

            return BadRequest(new
            {
                // Erros
            });
        }

        protected ActionResult CustomeReponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                // Notificar Erros
            }

            return CustomeReponse();
        }

        protected void NotificarErro(string mensagem)
        {

        }
    }
}
