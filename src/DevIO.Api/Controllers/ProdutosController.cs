using DevIO.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : MainController
    {
        public ProdutosController() { }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos() {  }

        [HttpGet("{id:guid}")]
        public async Task<IEnumerable<ProdutoViewModel>> ObterPorId(Guid id) { }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel) {  }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid id, ProdutoViewModel produtoViewModel) { }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id) { }
    }
}
