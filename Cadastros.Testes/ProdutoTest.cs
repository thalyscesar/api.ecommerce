using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cadastros.Testes
{
    
    public class ProdutoTest
    {
        [Fact]
        public void Produto_CriacaoProduto_ErroValorDeveSerZero()
        {
           // Assert
            Assert.Throws<DominioException>(() => new Produto(1, "123", "Carro", 0));
        }
    }
}
