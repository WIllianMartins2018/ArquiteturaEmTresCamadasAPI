﻿using DevIO.Business.Models;

namespace DevIO.Business.Interfaces.Repositories;

public interface IFornecedorRepository : IRepository<Fornecedor>
{
    Task<Fornecedor> ObterFornecedorEndereco(Guid id);
    Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);  
    Task<Endereco> ObterEnderecoPorFornecedor(Guid id);  
    Task RemoverEnderecoFornecedor(Endereco endereco);  
}
