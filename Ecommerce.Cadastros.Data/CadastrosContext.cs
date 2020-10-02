using Ecommerce.Cadastros.Domain;
using Ecommerce.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Cadastros.Data
{
    public class CadastrosContext:DbContext, IUnitOfWork
    {
        public CadastrosContext(DbContextOptions<CadastrosContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastrosContext).Assembly);
        }

        public async Task<bool> Commit()
        {
           return await SaveChangesAsync() > 0;
        }
    }
}
