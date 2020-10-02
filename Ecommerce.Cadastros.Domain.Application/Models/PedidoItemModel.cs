using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain.Application.Models
{
    public class PedidoItemModel
    {
        public int Id { get; set; }
        public ProdutoModel Produto { get; set; }
        public int Quantidade { get; set; }

        public string Imagem { get; set; }
    }
}
