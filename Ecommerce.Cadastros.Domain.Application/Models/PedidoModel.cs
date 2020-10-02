using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain.Application.Models
{
    public class PedidoModel
    {

        public PedidoModel()
        {
            this.Itens = new List<PedidoItemModel>();
        }

        public int Id { get; set; }
        public ClienteModel Cliente { get; set; }
        public List<PedidoItemModel> Itens { get; set; }

    }
}
