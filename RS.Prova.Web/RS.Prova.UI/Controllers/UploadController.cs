using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using RS.Prova.FileManager;
using System.Collections.Generic;
using System.IO;

namespace RS.Prova.UI.Controllers
{
    public class UploadController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoItensRepository _pedidoItensRepository;

        public UploadController(IPedidoItensRepository pedidoItensRepository, IClienteRepository clienteRepository, IProdutoRepository produtoRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _pedidoItensRepository = pedidoItensRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadProduto(IFormFile file)
        {
            if (file.Length > 0)
            {
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!fileExt.Equals("txt"))
                    return BadRequest("Formato invalido!");

                var lstPedidos = new List<PedidoItens>();

                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    var pedidoItensManager = new PedidoItensManager(_pedidoItensRepository, _produtoRepository);
                    pedidoItensManager.ProcessaArquivo(stream);
                }
            }

            return RedirectToAction("Index", "Cliente");
        }


        [HttpPost]
        public ActionResult UploadCliente(IFormFile file)
        {
            if (file.Length > 0)
            {
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!fileExt.Equals("txt"))
                    return BadRequest("Formato invalido!");

                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    var clienteManager = new ClienteManager(_clienteRepository);
                    clienteManager.ProcessaArquivo(stream);
                }
            }

            return RedirectToAction("Index", "Cliente");
        }
    }
}