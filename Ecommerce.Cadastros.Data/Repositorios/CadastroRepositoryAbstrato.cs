using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.Interfaces;
using Ecommerce.Core.Data;
using Ecommerce.Core.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Data.Repositorios
{
    public abstract class CadastroRepositoryAbstrato<T> : ICadastroRepository<T>
        where T : Entity


    {
        protected CadastrosContext _context;
        protected MongoDB _mongo;


        public IUnitOfWork UnitOfWork => _context;

        public CadastroRepositoryAbstrato(CadastrosContext context, IClientesDatabaseConfig configMongo)
        {
            this._context = context;
            _mongo = new MongoDB(configMongo);
        }

        public virtual void Adicionar(T entidade)
        {
            _context.Set<T>().Add(entidade);
        }

        public virtual void Atualizar(T entidade)
        {
            _context.Set<T>().Update(entidade);
        }

        public virtual void Excluir(int id)
        {
            T item = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(item);
        }

        public virtual async Task<T> ObterPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public abstract void AddMongo(T entidade);

        public abstract void DeleteMongo(int id);

        public abstract void UpdateMongo(T entidade);
    }
}
