using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS.Prova.Domain.Entities;

namespace RS.Prova.API.Models
{
    public class PedidoModel
    {
        public string Descricao { get; set; }

    }

    public static class PedidoModelExtensions
    {
        public static List<PedidoModel> ToPedidoModel(this IEnumerable<PedidoItens> pedidos)
        {
            var lstPedidoModel = new List<PedidoModel>();

            foreach (var pedido in pedidos)            
                    lstPedidoModel.Add(new PedidoModel() { Descricao = pedido.Produto.Descricao });            

            return lstPedidoModel;
        }

    }
}
