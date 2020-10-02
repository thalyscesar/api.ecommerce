using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain.Interfaces
{
    public interface IEstoqueService: IDisposable
    {
        Task<bool> DebitarEstoque(int  produtoId, int quantidade);

        Task<bool> ReporEstoque(int produtoId, int quantidade);
     

    }
}
