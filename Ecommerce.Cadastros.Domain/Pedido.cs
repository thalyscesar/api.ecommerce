using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ecommerce.Cadastros.Domain
{
    public class Pedido : Entity
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

        protected Pedido() { }

        public Pedido(int pedidoId, int clienteId)
        {
            this.Id = pedidoId;
            ClienteId = clienteId;
            _pedidoItems = new List<PedidoItem>();

            new ValidadorPedido().Valide(this);
        }

        public bool PedidoItemExistente(PedidoItem item)
        {
            return _pedidoItems.Any(p => p.ProdutoId == item.ProdutoId);
        }

        public void AdicionarItem(PedidoItem item)
        {
            _pedidoItems.Add(item);
        }

        public void AtualizarItemPedido(PedidoItem pedidoItem)
        {
            var itemExistente = PedidoItemExistente(pedidoItem);

            if (itemExistente)
            {
                var item = _pedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);
                _pedidoItems.Remove(item);
                _pedidoItems.Add(pedidoItem);
            }
            else
            {
                _pedidoItems.Add(pedidoItem);
            }
        }

        public void RemoverItens(List<int> itens)
        {
            foreach (var item in itens)
            {
                var itemExistente = _pedidoItems.FirstOrDefault(it => it.Id == item);

                if (itemExistente == null)
                {
                    _pedidoItems.RemoveAll(p => p.Id == item);
                }
            }
        }
    }

    public class ValidadorPedido : ValidadorAbstrato<Pedido>
    {
        public ValidadorPedido()
        {
            RuleFor(p => p.ClienteId).GreaterThan(0).WithMessage("Cliente não pode ser nulo");
        }
    }


}
