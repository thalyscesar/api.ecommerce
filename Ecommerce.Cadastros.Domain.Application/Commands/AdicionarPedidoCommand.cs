using Ecommerce.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain.Application.Commands
{
    public class AdicionarPedidoCommand : Command
    {
        public int ClienteId { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarPedidoValidation : AbstractValidator<AdicionarPedidoCommand>
        {
            public AdicionarPedidoValidation()
            {
                RuleFor(c => c.ClienteId)
                    .GreaterThan(0)
                    .WithMessage("Id do cliente inválido");

            }
        }
    }
}
