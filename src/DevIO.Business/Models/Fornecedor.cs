using DevIO.Business.Enum;
using DevIO.Business.ValueObjects;

namespace DevIO.Business.Models;

public class Fornecedor : Entity
{
    public string? Nome { get; set; }
    public string? Documento { get; set; }
    public ETipoFornecedor TipoFornecedor { get; set; }
    public Endereco? Endereco { get; set; }
    public bool Ativo { get; set; }
}

