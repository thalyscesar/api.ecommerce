using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.Interfaces;
using Ecommerce.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Ecommerce.Cadastros.Data.Repositorios
{
    public class ProdutoRepository : CadastroRepositoryAbstrato<Produto>
    {
        public ProdutoRepository(CadastrosContext contexto, IClientesDatabaseConfig config) : base(contexto, config) { }

        public override void AddMongo(Produto entidade)
        {
            _mongo.Produtos.InsertOne(entidade);
        }

        public override void DeleteMongo(int id)
        {
            _mongo.Produtos.DeleteOne(c => c.Id == id);
        }

        public override void UpdateMongo(Produto entidade)
        {
            _mongo.Produtos.ReplaceOne(c => c.Id == entidade.Id, entidade);
        }

        public async override Task<Produto> ObterPorId(int id)
        {
            Produto produto = await _mongo.Produtos.Find(p => p.Id == id).FirstOrDefaultAsync();

            return produto;
        }

        public async override Task<IEnumerable<Produto>> ObterTodos()
        {
            IEnumerable<Produto> produtos = await _mongo.Produtos.Find(p => true).ToListAsync();
            return produtos;
        }


    }
}
