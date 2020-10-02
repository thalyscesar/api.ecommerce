using Ecommerce.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain.Application.Commands
{
    public class RemoverPedidoDoBDQueFoiExcluidoDaTela : Command
    {
        public int PedidoId { get; private set; }
        public List<int> ItensPedido { get; private set; }

        public RemoverPedidoDoBDQueFoiExcluidoDaTela(int pedidoId, List<int> itensPedido)
        {
            this.PedidoId = pedidoId;
            this.ItensPedido = itensPedido;
        }
    }
}
