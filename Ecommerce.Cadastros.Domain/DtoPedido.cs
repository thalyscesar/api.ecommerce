using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain
{
    public class DtoPedido:Entity
    {
        public int ClienteId { get; set; }

        public DtoPedido(int id, int clienteId)
        {
            this.ClienteId = clienteId;
            this.Id = id;
        }
    }
}
