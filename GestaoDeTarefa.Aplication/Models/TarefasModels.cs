using GestaoDeTarefa.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Aplication.Models
{
    public class TarefasModels
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public Status Status { get;  set; }
        public DateTime DataCriacao { get;  set; }
        public DateTime? DataConclusao { get;  set; }
    }
}
