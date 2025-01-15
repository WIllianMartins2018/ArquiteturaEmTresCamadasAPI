using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces.Repositories;
using DevIO.Business.Interfaces.Services;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
            IProdutoService produtoService, 
            IMapper mapper, 
            INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos() 
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());                
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id) 
        {
            var produtoViewModel = await ObterProduto(id);
            
            if (produtoViewModel is null) return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel) 
        {
            if (!ModelState.IsValid) return CustomeReponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomeReponse(HttpStatusCode.Created, produtoViewModel);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid id, ProdutoViewModel produtoViewModel) 
        {
            if (id != produtoViewModel.Id)
            {
                NotificarErro("Os Ids informados não são iguais!");

                return CustomeReponse();
            }

            if (!ModelState.IsValid) return CustomeReponse(ModelState);

            var produtoAtualizacao = await ObterProduto(id);

            produtoAtualizacao.FornecedorId = produtoViewModel.FornecedorId;
            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoAtualizacao.Valor = produtoViewModel.Valor;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            return CustomeReponse(HttpStatusCode.NoContent);

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id) 
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel is null) return NotFound();

            await _produtoRepository.Remover(id);

            return CustomeReponse(HttpStatusCode.NoContent);
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutosPorFornecedor(id));
        }
    }
}
