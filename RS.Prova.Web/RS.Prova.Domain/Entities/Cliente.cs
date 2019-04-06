using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Email { get; set; }

        public bool ClienteAtivo { get; set; }

        public IEnumerable<PedidoItens> Pedidos { get; set; }
    }
}
