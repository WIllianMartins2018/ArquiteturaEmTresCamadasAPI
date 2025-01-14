using DevIO.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : MainController
    {
        public FornecedoresController() { }

        [HttpGet]
        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos() { }

        [HttpGet("{id:guid}")]
        public async Task<IEnumerable<FornecedorViewModel>> ObterPorId(Guid id) { }

        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel produtoViewModel) { }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel produtoViewModel) { }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id) { }
    }
}
