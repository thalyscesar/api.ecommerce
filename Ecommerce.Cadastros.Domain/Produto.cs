using FluentValidation;
using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using FluentValidation.Results;

namespace Ecommerce.Cadastros.Domain
{
    public class Produto : Entity
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
       

        protected Produto() { }

        public Produto(int id, string codigo, string nome,decimal valor)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nome = nome;
            this.Valor = valor;

            new ValidadorProduto().Valide(this);
        }
    }

    public class ValidadorProduto : ValidadorAbstrato<Produto>
    {
        public ValidadorProduto()
        {
            RuleFor(p => p.Codigo).NotNull().NotEmpty().WithMessage("Codigo não deve ser nulo nem vazio");
            RuleFor(p => p.Nome).NotEmpty().WithMessage("Nome não pode ser vazio");
            RuleFor(p => p.Valor).GreaterThan(0).WithMessage("Valor não pode ser menor que 0");
        }
    }

}
