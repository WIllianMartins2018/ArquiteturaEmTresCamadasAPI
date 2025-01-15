using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces.Repositories;
using DevIO.Business.Interfaces.Services;
using DevIO.Business.Models;
using DevIO.Business.Services;
using DevIO.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(
            IFornecedorRepository fornecedorRepository,
            IFornecedorService fornecedorService,
            IMapper mapper, 
            INotificador notificador) : base(notificador) 
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel is null) return NotFound();

            return fornecedorViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return CustomeReponse(ModelState);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            return CustomeReponse(HttpStatusCode.Created,fornecedorViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
            {
                NotificarErro("Os Ids informados não são iguais!");

                return CustomeReponse();
            }

            if (!ModelState.IsValid) return CustomeReponse(ModelState);

            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            return CustomeReponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel is null) return NotFound();

            await _fornecedorService.Remover(id);

            return CustomeReponse(HttpStatusCode.NoContent);
        }


        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}
