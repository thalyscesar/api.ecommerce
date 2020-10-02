using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ecommerce.Cadastros.Domain.ExcecoesDominio
{
    public class DominioException : Exception
    {
        public IList<ValidationFailure> Erros { get; private set; }

        public DominioException(ValidationResult validationResult)
        {
            this.Erros = validationResult.Errors;
        }

        public DominioException(string message):base(message)
        {
        }

        public override string Message
        {
            get
            {
                return string.Join("\n", this.Erros.Select(x => x.ErrorMessage));
            }
        }

        public string FirstErrorMessage
        {
            get
            {
                return this.Erros[0].ErrorMessage;
            }
        }
    }
}
