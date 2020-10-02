using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using FluentValidation;
using FluentValidation.Results;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Cadastros.Domain
{
    public class Entity  
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; protected set; }


        public void Validar<T>(T validador) where T : ValidadorAbstrato<T>
        {
            validador.Valide(validador);
        }

    }

    public interface IValidator<T> where T : class
    {
        void Valide(T instancia);
    }

    public abstract class ValidadorAbstrato<T> : AbstractValidator<T>, IValidator<T>
        where T : class
    {
        public void Valide(T instancia)
        {
            ValidationResult validationResult = this.Validate(instancia);
            if (!validationResult.IsValid)
                throw new DominioException(validationResult);
        }



    }
}
