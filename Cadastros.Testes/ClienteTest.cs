using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using System;
using Xunit;

namespace Cadastros.Testes
{
    public class ClienteTest
    {
        [Fact]
        public void Cliente_CriarCliente_ErroPreenchimentoDeCodigo()
        {
            // Assert
            Assert.Throws<DominioException>(() => new Cliente(0, "Marcos", null));
        }
    }
}
