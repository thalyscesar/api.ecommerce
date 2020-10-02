using System;
using Ecommerce.Core.Messages;
using FluentValidation;

namespace Ecommerce.Cadastros.Domain.Application.Commands
{
    public class AtualizarItemPedidoCommand : Command
    {
        public int Id { get; set; }
        public int ClienteId { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public int PedidoId { get; private set; }

        public AtualizarItemPedidoCommand( int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarItemPedidoValidation : AbstractValidator<AtualizarItemPedidoCommand>
    {
        public AtualizarItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .GreaterThan(0)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .GreaterThan(0)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade miníma de um item é 1");
        }
    }
}