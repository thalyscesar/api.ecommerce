using Ecommerce.Cadastros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain.Servicos
{
    public class EstoqueService : IEstoqueService
    {
        ICadastroRepository<Produto> _produtoRepository;

        public EstoqueService(ICadastroRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<bool> DebitarEstoque(int produtoId, int quantidade)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> ReporEstoque(int produtoId, int quantidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
