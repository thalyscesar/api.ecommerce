using Ecommerce.Cadastros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly ICadastroRepository<Cliente> _clienteRepository;

        public ClienteService(ICadastroRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
