﻿using DevIO.Business.Enum;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels;

public class FornecedorViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
    public required string Documento { get; set; }
    public int TipoFornecedor { get; set; }
    public bool Ativo { get; set; }
    public EnderecoViewModel? Endereco { get; set; }
    public IEnumerable<ProdutoViewModel>? Produtos { get; set; }
}
