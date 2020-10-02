using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreteApi.Domain
{
    public class Frete
    {
        public int QtdeItens { get; private set; }

        public Frete(int quantidadeItens)
        {
            this.QtdeItens = quantidadeItens;
        }

        public int CalcularFrete()
        {
           return CalculeValorDeAcordoComADistancia() * QtdeItens;
        }

        public int CalculeValorDeAcordoComADistancia()
        {
           Random numero = new Random();
           return numero.Next(5, 11);
        }


    }
}
