using DevIO.Business.Interfaces.Repositories;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext dbContext) : base(dbContext) {  }

    public async Task<Produto> ObterProdutoFornecedor(Guid id)
    {
        return await DbContext.Produtos.AsNoTracking()
                                .Include(f => f.Fornecedor)
                                .FirstOrDefaultAsync(p => p.Id == id);

    }

    public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
    {
        return await DbContext.Produtos.AsNoTracking()
                               .Include(f => f.Fornecedor)
                               .OrderBy(f => f.Nome)
                               .ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
    {
        return await Buscar(p => p.FornecedorId == fornecedorId);
    }
}
