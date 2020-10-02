using System;
using Ecommerce.Core.Messages;
using FluentValidation;

namespace Ecommerce.Cadastros.Domain.Application {
    public class RemoverPedidoCommand : Command
    {
        public int PedidoId { get; private set; }


        public RemoverPedidoCommand(int pedidoId)
        {
            PedidoId = pedidoId;
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoverItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoverItemPedidoValidation : AbstractValidator<RemoverPedidoCommand>
    {
        public RemoverItemPedidoValidation()
        {
            RuleFor(c => c.PedidoId)
                .GreaterThan(0)
                .WithMessage("Id do item inválido");

        }
    }

    
}