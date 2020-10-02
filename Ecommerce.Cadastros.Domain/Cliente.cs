using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using FluentValidation;

namespace Ecommerce.Cadastros.Domain
{
    public class Cliente:Entity
    {
        public string Codigo { get; set; }

        public string Nome { get; private set; }

        protected Cliente() { }

        public Cliente(int id, string nome, string codigo)
        {
            this.Id = id;
            this.Nome = nome;

            this.Codigo = codigo;

            new ValidadorCliente().Valide(this);
        }
    }

    public class ValidadorCliente : ValidadorAbstrato<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(c => c.Codigo).NotNull().NotEmpty().WithMessage("Codigo não pode estar vazio e nem nulo");
            RuleFor(c => c.Nome).NotNull().NotEmpty().WithMessage("Nome não pode estar vazio e nem nulo");
        }
    }


}
