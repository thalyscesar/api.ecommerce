using Ecommerce.Cadastros.Data;
using Ecommerce.Cadastros.Data.Repositorios;
using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.Application;
using Ecommerce.Cadastros.Domain.Application.Commands;
using Ecommerce.Cadastros.Domain.Application.Services;
using Ecommerce.Cadastros.Domain.Interfaces;
using Ecommerce.Cadastros.Domain.Servicos;
using Ecommerce.Core.Comunicacao;
using Ecommerce.Core.Domain;
using Ecommerce.Core.Messages.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace E_Commerce.Api
{
    public class Startup
    {
        private string _cors = "Ecommerce";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c => c.AddPolicy(_cors, b =>
            {
                b.WithOrigins("http://localhost:4200");
                b.WithMethods("GET", "POST", "PUT", "DELETE");
                b.AllowAnyHeader();
                b.AllowCredentials();
                b.AllowAnyMethod();

            }));

            services.AddControllers();
            services.AddDbContext<CadastrosContext>(options =>
               options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            var clientesDatabaseConfig = new ClientesDatabaseConfig();


            Configuration.Bind(nameof(ClientesDatabaseConfig), clientesDatabaseConfig);
            services.AddSingleton(typeof(IClientesDatabaseConfig), clientesDatabaseConfig);

            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICadastroRepository<Cliente>, ClienteRepository>();

            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<ICadastroRepository<Produto>, ProdutoRepository>();

            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddMediatR(typeof(Startup));

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverPedidoDoBDQueFoiExcluidoDaTela, bool>, PedidoCommandHandler>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_cors);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
