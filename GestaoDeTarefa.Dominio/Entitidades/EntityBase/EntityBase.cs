using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Dominio.Entitidades.EntityBase
{
    public  class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

        protected EntityBase()
        {
            DataCriacao = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
