using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.Interfaces;
using Ecommerce.Core.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Data.Repositorios
{
    public class ClienteRepository : CadastroRepositoryAbstrato<Cliente>
    {
        public ClienteRepository(CadastrosContext context, IClientesDatabaseConfig clientesDatabaseConfig) : base(context,clientesDatabaseConfig)
        {
        }

        public override void AddMongo(Cliente entidade)
        {
            _mongo.Clientes.InsertOne(entidade);
        }

        public override void DeleteMongo(int id)
        {
            _mongo.Clientes.DeleteOne(c => c.Id == id);
        }

        public override void UpdateMongo(Cliente entidade)
        {
            _mongo.Clientes.ReplaceOne(c => c.Id == entidade.Id,entidade);
        }

        public override async Task<Cliente> ObterPorId(int id)
        {
            return await _mongo.Clientes.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _mongo.Clientes.Find(c => true).ToListAsync();
        }
    }
}
