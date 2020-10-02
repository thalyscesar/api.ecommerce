using Ecommerce.Cadastros.Domain.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain.Application.Services
{
    public interface IClienteAppService : IDisposable
    {
        Task<ClienteModel> ObterPorId(int id);
        Task<IEnumerable<ClienteModel>> ObterTodos();
        Task Adicionar(ClienteModel model);
        Task Atualizar(ClienteModel model);
        Task Excluir(ClienteModel model);
    }
}
