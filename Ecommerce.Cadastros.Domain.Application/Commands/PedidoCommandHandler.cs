using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Cadastros.Domain.Application.Commands;
using Ecommerce.Core.Comunicacao;
using Ecommerce.Core.Domain;
using Ecommerce.Core.Messages;
using Ecommerce.Core.Messages.Notificacao;
using MediatR;
using MongoDB.Driver;
namespace Ecommerce.Cadastros.Domain.Application
{
    public class PedidoCommandHandler :
        IRequestHandler<AdicionarItemPedidoCommand, bool>,
        IRequestHandler<AtualizarItemPedidoCommand, bool>,
        IRequestHandler<AdicionarPedidoCommand, bool>,
        IRequestHandler<AtualizarPedidoCommand, bool>,
        IRequestHandler<RemoverPedidoCommand, bool>,
        IRequestHandler<RemoverPedidoDoBDQueFoiExcluidoDaTela, bool>

    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private Data.MongoDB _mongo;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository,
                                    IMediatorHandler mediatorHandler, IClientesDatabaseConfig configMongo)
        {
            _pedidoRepository = pedidoRepository;
            _mediatorHandler = mediatorHandler;
            _mongo = new Data.MongoDB(configMongo);

        }


        public async Task<bool> Handle(AdicionarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var pedido = await _pedidoRepository.ObterPedidoPorCliente(message.ClienteId);

            if (pedido == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("pedido", "Pedido não encontrado!"));
                return false;
            }

            var pedidoItem = new PedidoItem(0, message.ProdutoId, message.Quantidade, pedido.Id);
            _pedidoRepository.AdicionarItem(pedidoItem);
            await _pedidoRepository.UnitOfWork.Commit();

            _mongo.PedidosItens.InsertOne(new DtoPedidoItem(pedidoItem.Id, pedidoItem.Quantidade, pedidoItem.ProdutoId, pedidoItem.Pedido.Id));

            return true;
        }

        public async Task<bool> Handle(AtualizarItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var pedido = await _pedidoRepository.ObterPorId(message.PedidoId);

            pedido.AtualizarItemPedido(new PedidoItem(message.Id, message.ProdutoId, message.Quantidade, message.PedidoId));
            var pedidoItem = await _pedidoRepository.ObterItemPorPedido(pedido.Id, message.ProdutoId);

            _pedidoRepository.AtualizarItem(pedidoItem);
            return true;
        }

        public async Task<bool> Handle(AdicionarPedidoCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = new Pedido(0, request.ClienteId);
            _pedidoRepository.Adicionar(pedido);
            await _pedidoRepository.UnitOfWork.Commit();


            _mongo.Pedidos.InsertOne(new DtoPedido(pedido.Id, pedido.ClienteId));

            return true;
        }

        public async Task<bool> Handle(AtualizarPedidoCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = await _pedidoRepository.ObterPorId(request.PedidoId);

            if (pedido == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("pedido", "Pedido não encontrado!"));
                return false;
            }

            _pedidoRepository.Atualizar(pedido);
            return true;
        }

        public async Task<bool> Handle(RemoverPedidoCommand request, CancellationToken cancellationToken)
        {
            _pedidoRepository.Excluir(new Pedido(request.PedidoId, 0));
            if (await _pedidoRepository.UnitOfWork.Commit())
            {
                _mongo.Pedidos.DeleteOne(p => p.Id == request.PedidoId);
            }
            return true;
        }

        public async Task<bool> Handle(RemoverPedidoDoBDQueFoiExcluidoDaTela request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepository.ObterPorId(request.PedidoId);

            _pedidoRepository.Atualizar(pedido);
            return true;
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }

    }
}