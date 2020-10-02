using Ecommerce.Cadastros.Data;
using Ecommerce.Cadastros.Domain.Application.Models;
using Ecommerce.Cadastros.Domain.Interfaces;
using Ecommerce.Cadastros.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {

        private readonly IClienteService _clienteService;
        private readonly ICadastroRepository<Cliente> _clienteRepository;

        public ClienteAppService(IClienteService clienteService, ICadastroRepository<Cliente> clienteRepository)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(ClienteModel model)
        {
            var cliente = ViewToDomain(model);

            _clienteRepository.Adicionar(cliente);
            await _clienteRepository.UnitOfWork.Commit();
            _clienteRepository.AddMongo(cliente);
        }

        public async Task Atualizar(ClienteModel model)
        {
            var cliente = ViewToDomain(model);

            _clienteRepository.Atualizar(cliente);
            await _clienteRepository.UnitOfWork.Commit();
            _clienteRepository.UpdateMongo(cliente);
        }

        public async Task Excluir(ClienteModel model)
        {

            _clienteRepository.Excluir(model.Id);
            await _clienteRepository.UnitOfWork.Commit();
            _clienteRepository.DeleteMongo(model.Id);
        }

        public async Task<ClienteModel> ObterPorId(int id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            return DomainToView(cliente);
        }

        public async Task<IEnumerable<ClienteModel>> ObterTodos()
        {
            var clientes = await _clienteRepository.ObterTodos();
            return clientes.Select(c => DomainToView(c));
        }

        public ClienteModel DomainToView(Cliente cliente)
        {
            return new ClienteModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Codigo = cliente.Codigo
            };
        }

        public Cliente ViewToDomain(ClienteModel model)
        {
            return new Cliente(model.Id, model.Nome, model.Codigo);
        }

        public void Dispose()
        {
            _clienteService?.Dispose();
            _clienteRepository?.Dispose();
        }
    }
}

