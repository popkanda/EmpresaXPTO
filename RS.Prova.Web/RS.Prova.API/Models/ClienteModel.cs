using RS.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS.Prova.API.Models
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public bool ClienteAtivo { get; set; }

        public List<PedidoModel> Pedidos { get; set; }

    }

    public static class ClienteModelExtensions
    { 

        public static ClienteModel ToClienteModel(this Cliente entity)
        {
            return new ClienteModel()
            {
                Nome = entity.Nome,
                Sobrenome = entity.Sobrenome,
                Sexo = entity.Sexo,
                DataNascimento = entity.DataNascimento,
                Email = entity.Email,
                ClienteAtivo = entity.ClienteAtivo,
                Pedidos = entity.Pedidos?.ToPedidoModel()
            };
        }

    }
}
