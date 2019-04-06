using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS.Prova.Data.EF.Repositories;
using RS.Prova.Domain.Contracts.Repositories;

namespace RS.Prova.UI.Controllers
{
    public class PedidoItensController : Controller
    {
        readonly IPedidoItensRepository _pedidoItensRepository;
        public PedidoItensController(IPedidoItensRepository pedidosItensRepository)
        {
            _pedidoItensRepository = pedidosItensRepository;
        }

        public IActionResult Index(int id)
        {
            var lstPedidos = _pedidoItensRepository.GetByClienteIdWithProdutos(id).ToList();
            
            return View(lstPedidos);
        }
    }
}