using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain
{
    public class DtoPedidoItem:Entity
    {
        public int Quantidade { get; private set; }
        public int ProdutoId { get; private set; }
        public int PedidoId { get; private set; }

        public DtoPedidoItem(int id,int quantidade, int produtoId,int pedidoId)
        {
            this.Id = id;
            this.Quantidade = quantidade;
            this.ProdutoId = produtoId;
            this.PedidoId = pedidoId;
        }
    }
}
