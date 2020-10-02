using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain.Application.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
     
        public decimal Valor { get; set; }

    }
}
