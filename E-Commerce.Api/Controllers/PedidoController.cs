using Ecommerce.Cadastros.Data.Repositorios;
using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.Application;
using Ecommerce.Cadastros.Domain.Application.Commands;
using Ecommerce.Cadastros.Domain.Application.Models;
using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using Ecommerce.Core.Comunicacao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IMediatorHandler mediatorHandler, IPedidoRepository pedidoRepository)
        {
            _mediatorHandler = mediatorHandler;
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] PedidoModel model)
        {
            try
            {
                AdicionarPedidoCommand adicionarPedidoCommand = new AdicionarPedidoCommand();
                adicionarPedidoCommand.ClienteId = model.Cliente.Id;

                await _mediatorHandler.EnviarComando(adicionarPedidoCommand);
                foreach (var item in model.Itens)
                {
                    AdicionarItemPedidoCommand adicionarItemPedidoCommand = new AdicionarItemPedidoCommand(item.Produto.Id, item.Quantidade, model.Cliente.Id);
                    await _mediatorHandler.EnviarComando(adicionarItemPedidoCommand);

                }

                return true;
            }
            catch (DominioException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //[HttpGet]
        //public async Task<IEnumerable<Pedido>> Get()
        //{
        //    return await pedido.ObterTodos();
        //}

        //[HttpGet("{id}")]
        //public async Task<ProdutoModel> Get(int id)
        //{
        //    ProdutoModel model = await _produtoAppService.ObterPorId(id);
        //    if (model == null) NotFound();
        //    return model;
        //}

        [Route("{id:int}")]
        [HttpPut]
        public async Task<string> Put(int id, [FromBody] PedidoModel model)
        {
            try
            {
                AtualizarPedidoCommand atualizarPedidoCommand = new AtualizarPedidoCommand(model.Id, model.Cliente.Id);

                await _mediatorHandler.EnviarComando(atualizarPedidoCommand);

                foreach (var item in model.Itens)
                {
                    AtualizarItemPedidoCommand adicionarItemPedidoCommand = new AtualizarItemPedidoCommand(item.Produto.Id, item.Quantidade);
                    await _mediatorHandler.EnviarComando(adicionarItemPedidoCommand);

                }

            }
            catch (DominioException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                RemoverPedidoCommand removerPedidoCommand = new RemoverPedidoCommand(id);
                await _mediatorHandler.EnviarComando(removerPedidoCommand);


            }
            catch (DominioException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}
