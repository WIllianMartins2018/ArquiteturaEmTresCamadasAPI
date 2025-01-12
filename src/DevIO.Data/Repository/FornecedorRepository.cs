using DevIO.Business.Interfaces.Repositories;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext dbContext) : base(dbContext) { }


        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await DbContext.Fornecedores.AsNoTracking()
                                               .Include(c => c.Endereco)
                                               .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await DbContext.Fornecedores.AsNoTracking()
                                   .Include(c => c.Produtos)
                                   .Include(c => c.Endereco)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await DbContext.Enderecos.AsNoTracking()
                                            .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }


        public async Task RemoverEnderecoFornecedor(Endereco endereco)
        {
            DbContext.Enderecos.Remove(endereco);

            await SaveChanges();
        }
    }
}
