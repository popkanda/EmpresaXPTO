using RS.Prova.Domain.Contracts.Repositories;
using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RS.Prova.FileManager
{
    public class ClienteManager
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteManager(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void ProcessaArquivo(string path)
        {
            var lst = TraduzArquivo(path);
            PersisteDados(lst);
        }

        public List<Cliente> TraduzArquivo(string path)
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
        public List<Cliente> TraduzArquivo(StreamReader stream)
        {
            var lstClientes = new List<Cliente>();

            var registros = stream.ReadToEnd().Split(';');
            for (int i = 0; i <= registros.Length - 1; i++)
            {
                string[] campos = registros[i].Split(',');

                try
                {
                    lstClientes.Add(new Cliente()
                    {
                        Id = Convert.ToInt32(campos[0]),
                        Nome = campos[1],
                        Sobrenome = campos[2],
                        DataNascimento = DateTime.ParseExact(campos[3], "dd/MM/yyyy", null),
                        Sexo = campos[4],
                        Email = campos[5],
                        ClienteAtivo = Convert.ToBoolean(campos[6])
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro na leitura do arquivo de Cliente, Linha:" + i + 1);
                }
            }

            return lstClientes;
        }

        public void PersisteDados(List<Cliente> lstClientes)
        {
            foreach (var cliente in lstClientes)
            {
                /* Se não existe, liga o IDENTITY_INSERT para utilizar o ID do arquivo */
                if (_clienteRepository.GetById(cliente.Id) == null)
                    _clienteRepository.ExecuteWithIdentityInsertRemoval(cliente);
                else
                    _clienteRepository.InsertOrUpdate(cliente);

                _clienteRepository.SaveChanges();
            }
        }
    }
}
