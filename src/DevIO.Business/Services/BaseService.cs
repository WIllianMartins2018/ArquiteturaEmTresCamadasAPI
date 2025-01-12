using DevIO.Business.Models;
using FluentValidation;

namespace DevIO.Business.Services;

public abstract class BaseService
{
    protected void  Notificar(string mensagem)
    {

    }

    protected bool ExecutarValidacao<TValidator, TEntity>(TValidator validacao, TEntity entidade) 
        where TValidator : AbstractValidator<TEntity> 
        where TEntity : Entity
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true ;

        // Lançamento de Notificações

        return false;
    }
}
