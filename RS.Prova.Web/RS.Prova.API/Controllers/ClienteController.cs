using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.API.Models;

namespace RS.Prova.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            //expoem a interface gerada pela dependencia a todo o escopo do controller
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Busca os dados na base
            var data = await _clienteRepository.GetWithProdutos();

            //Converte a entidade para model
            return Ok(data.Select(d => d.ToClienteModel()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //Busca os dados na base
            var data = await _clienteRepository.GetByClienteIdWithProdutos(id);

            //Se o cliente nao existe, retorna um erro
            if (data == null)
                return BadRequest("Cliente inexistente");

            //Converte a entidade para model
            return Ok(data.ToClienteModel());
        }

    }
}