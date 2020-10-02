using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using FreteApi.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreteController : ControllerBase
    {
        [HttpGet("calcularfrete")]
        public int Calcularfrete(int quantidade)
        {
            Frete frete = new Frete(quantidade);
            return frete.CalcularFrete();
        }
    }
}
