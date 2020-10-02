using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NerdStore.Vendas.Application.Queries.ViewModels;

namespace Ecommerce.Cadastros.Domain.Application.Queries
{
    public interface IPedidoQueries
    {


        Task<PedidoViewModel> ObterPedidos(int clienteId);
        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(int clienteId);
    }
}