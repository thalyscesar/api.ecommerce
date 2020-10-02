using Ecommerce.Cadastros.Domain;
using Ecommerce.Core.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Data
{
    public class MongoDB
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public MongoDB(IClientesDatabaseConfig config)
        {
            _client = new MongoClient(config.ConnectionString);
            _database = _client.GetDatabase(config.DatabaseName);
        }

        public IMongoCollection<Cliente> Clientes { get { return _database.GetCollection<Cliente>("clientes"); } }

        public IMongoCollection<Produto> Produtos { get { return _database.GetCollection<Produto>("produtos"); } }

        public IMongoCollection<DtoPedido> Pedidos { get { return _database.GetCollection<DtoPedido>("pedidos"); } }

        public IMongoCollection<DtoPedidoItem> PedidosItens { get { return _database.GetCollection<DtoPedidoItem>("pedidositens"); } }
    }
}
