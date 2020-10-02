using Ecommerce.Cadastros.Domain.Application.Models;
using Ecommerce.Cadastros.Domain.Application.Services;
using Ecommerce.Cadastros.Domain.ExcecoesDominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController: ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] ProdutoModel model)
        {
            try
            {
                await _produtoAppService.AdicionarProduto(model);
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

        [HttpGet]
        public  IEnumerable<ProdutoModel> Get()
        {
            return  _produtoAppService.ObterTodos().Result;
        }

        [HttpGet("{id}")]
        public async Task<ProdutoModel> Get(int id)
        {
            ProdutoModel model = await _produtoAppService.ObterPorId(id);
            if (model == null) NotFound();
            return model;
        }

        [Route("{id:int}")]
        [HttpPut]
        public async Task<string> Put(int id, [FromBody] ProdutoModel model)
        {
            try
            {
                await _produtoAppService.AtualizarProduto(model);
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

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                await _produtoAppService.ExcluirProduto(new ProdutoModel() { Id = id });

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
