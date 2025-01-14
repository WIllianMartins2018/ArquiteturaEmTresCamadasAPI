using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels;

public class EnderecoViewModel
{
    public Guid Id { get; set; }
    public Guid FornecedorId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public required string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public required string Numero { get; set; }

    public string? Complemento { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public required string Bairro { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
    public required string Cep { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public required string Cidade { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public required string Estado { get; set; }
}
