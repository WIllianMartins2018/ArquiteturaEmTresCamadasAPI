using DevIO.Business.Interfaces.Services;
using DevIO.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace DevIO.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomeReponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode)    
                };
            }

            return BadRequest(new
            {
                erros = _notificador.ObterNotificacaoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomeReponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)  NotificarErroModelInvalida(modelState);

            return CustomeReponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception is null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(erroMsg);
            }
        }


        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
