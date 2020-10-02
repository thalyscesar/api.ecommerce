using Ecommerce.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Domain.Interfaces
{
    public interface ICadastroRepository
        <T> : IDisposable,IRepository
    {
        void Adicionar(T entidade);
        void Excluir(int id);
        void Atualizar(T entidade);

        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(int Id);

        void AddMongo(T entidade);
        void DeleteMongo(int id);
        void UpdateMongo(T entidade);
    }
}
