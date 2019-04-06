using Microsoft.AspNetCore.Mvc;
using RS.Prova.Domain.Contracts.Repositories;

namespace RS.Prova.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {            
            return View(_clienteRepository.Get());
        }
    }
}