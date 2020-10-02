using Ecommerce.Cadastros.Domain;
using Ecommerce.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Data.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly CadastrosContext _context;

        public PedidoRepository(CadastrosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Pedido> ObterPorId(int id)
        {
            return await  _context.Pedidos.Include(p => p.PedidoItems).Where(p => p.Id == id).FirstAsync();
        }

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public void Excluir(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
        }


        public async Task<PedidoItem> ObterItemPorId(int id)
        {
            return await _context.PedidosItens.FindAsync(id);
        }

        public async Task<PedidoItem> ObterItemPorPedido(int pedidoId, int produtoId)
        {
            return await _context.PedidosItens.FirstOrDefaultAsync(p => p.ProdutoId == produtoId && p.PedidoId == pedidoId);
        }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            _context.PedidosItens.Add(pedidoItem);
        
        }

        public void AtualizarItem(PedidoItem pedidoItem)
        {
            _context.PedidosItens.Update(pedidoItem);
        }

        public void RemoverItem(PedidoItem pedidoItem)
        {
            _context.PedidosItens.Remove(pedidoItem);
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Pedido> ObterPedidoPorCliente(int clienteId)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.Cliente.Id == clienteId);
        }
    }
}