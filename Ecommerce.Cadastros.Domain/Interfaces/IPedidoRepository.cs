using Ecommerce.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain
{
    public interface IPedidoRepository : IRepository
    {
        Task<Pedido> ObterPorId(int id);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
        void Excluir(Pedido pedido);

        Task<Pedido> ObterPedidoPorCliente(int clienteId);

        Task<PedidoItem> ObterItemPorId(int id);
        Task<PedidoItem> ObterItemPorPedido(int pedidoId, int produtoId);
        void AdicionarItem(PedidoItem pedidoItem);
        void AtualizarItem(PedidoItem pedidoItem);
        void RemoverItem(PedidoItem pedidoItem);
    }
}