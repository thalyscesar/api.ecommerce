using System;
using FluentValidation;
using Ecommerce.Core.Messages;

namespace Ecommerce.Cadastros.Domain.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public int  ClienteId { get; set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }

        public AdicionarItemPedidoCommand(int produtoId, int quantidade,int clienteId)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ClienteId = clienteId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {

            RuleFor(c => c.ProdutoId)
                .GreaterThan(0)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.ClienteId)
              .GreaterThan(0)
              .WithMessage("Id do cliente inválido");



            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade miníma de um item é 1");
        }
    }
}