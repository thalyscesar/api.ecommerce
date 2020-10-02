using Ecommerce.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain.Application.Commands
{
    public class AtualizarPedidoCommand : Command
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }

        public AtualizarPedidoCommand(int pedidoId, int clienteId)
        {
            this.PedidoId = pedidoId;
            this.ClienteId = clienteId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarPedidoValidation : AbstractValidator<AtualizarPedidoCommand>
        {
            public AtualizarPedidoValidation()
            {
                RuleFor(c => c.ClienteId)
                    .GreaterThan(0)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.PedidoId)
                    .GreaterThan(0)
                    .WithMessage("Id do produto inválido");
            }
        }
    }
}
