using Ecommerce.Cadastros.Domain.Application.Models;
using Ecommerce.Cadastros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly ICadastroRepository<Produto> _produtoRepository;

        public ProdutoAppService(ICadastroRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarProduto(ProdutoModel model)
        {
            var produto = ViewToDomain(model);

            _produtoRepository.Adicionar(produto);
            await _produtoRepository.UnitOfWork.Commit();
            _produtoRepository.AddMongo(produto);
        }

        public async Task AtualizarProduto(ProdutoModel model)
        {
            var produto = ViewToDomain(model);

            _produtoRepository.Atualizar(produto);
            await _produtoRepository.UnitOfWork.Commit();
            _produtoRepository.UpdateMongo(produto);

        }

        public async Task ExcluirProduto(ProdutoModel model)
        {
           
            _produtoRepository.Excluir(model.Id);
            await _produtoRepository.UnitOfWork.Commit();
            _produtoRepository.DeleteMongo(model.Id);
        }

        public async Task<ProdutoModel> ObterPorId(int id)
        {

           return DomainToView( await _produtoRepository.ObterPorId(id));
        }

        public async  Task<IEnumerable<ProdutoModel>> ObterTodos()
        {
            var produtos = await  _produtoRepository.ObterTodos();
            
            return produtos.Select(c => DomainToView(c));
        }

        public ProdutoModel DomainToView(Produto produto)
        {
            return new ProdutoModel()
            {
                Codigo = produto.Codigo,
                Id = produto.Id,
                Nome = produto.Nome,
                Valor = produto.Valor
            };
        }

        public Produto ViewToDomain(ProdutoModel model)
        {
            return new Produto(model.Id,model.Codigo, model.Nome, model.Valor);
        }

        public void Dispose()
        {
            //_estoqueService?.Dispose();

            _produtoRepository?.Dispose();
        }
    }
}
