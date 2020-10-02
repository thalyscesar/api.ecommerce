using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain
{
    public class PedidoItem : Entity
    {
        public int Quantidade { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }

        public PedidoItem(int id, int produtoId, int quantidade, int pedidoId)
        {
            this.Id = id;
            this.ProdutoId = produtoId;
            this.Quantidade = quantidade;
            this.PedidoId = pedidoId;
        }

        internal void AssociarPedido(int pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Produto.Valor * this.Quantidade;
        }
    }

    public class ValidadorPedidoItem : ValidadorAbstrato<PedidoItem>
    {

        public ValidadorPedidoItem()
        {
            RuleFor(it => it.Produto).NotNull().WithMessage("Produto esta invalido");
            RuleFor(it => it.Quantidade).GreaterThan(0).WithMessage("Quantidade esta invalido");
            RuleFor(it => it.PedidoId).GreaterThan(0).WithMessage("Quantidade esta invalido");


        }
    }
}
