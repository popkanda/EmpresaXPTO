using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Domain.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }


        public IEnumerable<PedidoItens> Pedidos { get; set; }
    }
}
