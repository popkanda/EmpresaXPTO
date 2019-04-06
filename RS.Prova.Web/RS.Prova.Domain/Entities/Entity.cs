using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Prova.Domain.Entities
{
    /* classe padrão que todas as entidades herdarão */
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
    }
}
