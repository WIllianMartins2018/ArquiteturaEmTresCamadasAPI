using DevIO.Business.Enum;
using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Validations;

public class FornecedorValidation : AbstractValidator<Fornecedor>
{
    public FornecedorValidation()
    {
        RuleFor(f => f.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(f => f.TipoFornecedor == ETipoFornecedor.PessoaFisica, () =>
        {
            RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyName}.");

            RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                .WithMessage("O Documento Fornecido é Inválido");

        });

        When(f => f.TipoFornecedor == ETipoFornecedor.PessoaJuridica, () =>
        {
            RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
               .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyName}.");

            RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
               .WithMessage("O Documento Fornecido é Inválido");
        });



    }
}
