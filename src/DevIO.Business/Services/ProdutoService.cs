﻿using DevIO.Business.Interfaces.Repositories;
using DevIO.Business.Interfaces.Services;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services;

public class ProdutoService : BaseService, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Adicionar(Produto produto)
    {
        if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

        var produtoExistente = _produtoRepository.ObterPorId(produto.Id);

        if (produtoExistente is not null)
        {
            Notificar("Já Existe um produto com o IdInformado");
            return;
        }

        await _produtoRepository.Adicionar(produto);
    }

    public async Task Atualizar(Produto produto)
    {
        if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

        await _produtoRepository.Atualizar(produto);
    }

    public async Task Remover(Guid id)
    {
        await _produtoRepository.Remover(id);
    }
    public void Dispose()
    {
        _produtoRepository.Dispose();
    }
}
