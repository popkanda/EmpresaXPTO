using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Domain.Entities
{
    public class PedidoItens : Entity
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
