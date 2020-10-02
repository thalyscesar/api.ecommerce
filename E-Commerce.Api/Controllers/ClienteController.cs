using Ecommerce.Cadastros.Domain;
using Ecommerce.Cadastros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Cadastros.Domain.Application.Models;
using Ecommerce.Cadastros.Domain.Application.Services;
using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using Npgsql;
using MongoDB.Driver;
using Ecommerce.Core.Domain;

namespace E_Commerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController: ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IClientesDatabaseConfig _settingsMongo;

        public ClienteController(IClienteAppService clienteAppService, IClientesDatabaseConfig settings)
        {
            _clienteAppService = clienteAppService;
            _settingsMongo = settings;
        }

        
        [HttpPost]
        public async Task<string> Post([FromBody] ClienteModel model)
        {
            try
            {
                await _clienteAppService.Adicionar(model);
            }
            catch (DominioException ex)
            {
                return  ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;

        }

        [HttpGet]
        public  IEnumerable<ClienteModel> Get() 
        {
            return _clienteAppService.ObterTodos().Result;
        }

        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            ClienteModel model = _clienteAppService.ObterPorId(id).Result;
            if (model == null) NotFound();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] ClienteModel model)
        {
            try
            {
                await _clienteAppService.Atualizar(model);
            }
            catch (DominioException ex)
            {
                return  ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
               await _clienteAppService.Excluir(new ClienteModel() { Id = id});
              
            }
            catch (DominioException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }



    }
}
