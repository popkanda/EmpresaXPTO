using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace RS.Prova.FileManager
{
    public class PedidoItensManager
    {

        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoItensRepository _pedidoItensRepository;

        public PedidoItensManager(IPedidoItensRepository pedidoItensRepository, IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoItensRepository = pedidoItensRepository;
        }

        public void ProcessaArquivo(string path)
        {
            var lst = TraduzArquivo(path);
            PersisteDados(lst);
        }

        public List<PedidoItens> TraduzArquivo(string path)
        {
            using (var stream = new StreamReader(path))
            {
                return this.TraduzArquivo(stream);
            }
        }

        public void ProcessaArquivo(StreamReader stream)
        {
            var lst = TraduzArquivo(stream);
            PersisteDados(lst);
        }
        public List<PedidoItens> TraduzArquivo(StreamReader stream)
        {
            var lstPedidoItens = new List<PedidoItens>();

            var registros = stream.ReadToEnd().Split(';');
            for (int i = 0; i <= registros.Length - 1; i++)
            {
                string[] campos = registros[i].Split(',');

                try
                {
                    int produtoID = Convert.ToInt32(campos[0]);
                    string descricaoProduto = campos[2];
                    int clienteID = Convert.ToInt32(campos[1]);

                    lstPedidoItens.Add(new PedidoItens()
                    {
                        ClienteId = clienteID,
                        ProdutoId = produtoID,
                        Produto = new Produto() { Id = Convert.ToInt32(campos[0]), Descricao = campos[2] }
                    });

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro na leitura do arquivo de Cliente, Linha:" + i + 1);
                }
            }

            return lstPedidoItens;
        }

        public void PersisteDados(List<PedidoItens> lstPedidos)
        {
            foreach (var pedido in lstPedidos)
            {
                //Se o ID nao existir na base, ignora o identity 
                if (_produtoRepository.GetById(pedido.Produto.Id) == null)
                    _produtoRepository.ExecuteWithIdentityInsertRemoval(pedido.Produto);

                //Usa o Identity, pois é uma tabela 1 -> N
                _pedidoItensRepository.InsertOrUpdate(pedido);

            }

            _produtoRepository.SaveChanges();
            _pedidoItensRepository.SaveChanges();
        }
    }
}
