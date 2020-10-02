using Ecommerce.Cadastros.Domain.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain.Application.Services
{
    public interface IProdutoAppService: IDisposable
    {
        Task<ProdutoModel> ObterPorId(int id);
        Task<IEnumerable<ProdutoModel>> ObterTodos();
        Task AdicionarProduto(ProdutoModel model);
        Task AtualizarProduto(ProdutoModel model);
        Task ExcluirProduto(ProdutoModel model);
    }
}
