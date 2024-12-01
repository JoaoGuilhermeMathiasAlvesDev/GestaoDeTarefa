using GestaoDeTarefa.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Dominio.Entitidades
{
    public class Tarefa : EntityBase.EntityBase
    {
        public Tarefa(string nome, string descricao, Status status)
        {
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }

        public Tarefa()
        {
            
        }

        public string Nome { get;private set; }
        public string Descricao { get;private set; }
        public Status Status { get;private set; }
        public DateTime DataCriacao { get;private set; }
        public DateTime? DataConclusao {get;private set;}


        public void SetNome(string nome) => Nome = nome;
        public void SetDescricao(string descricao) => Descricao = descricao;
        
        public void setStatus(Status status) => Status = status;

        public void SetDataConclusao(DateTime? dataConclusao, Status status)
        {
            if (status == Status.Concluido) { DataConclusao = DateTime.Now; Status = status; }
            else
            {
                DataConclusao = null; Status = status;

            }
        }

        public List<Tarefa> obterPorStatus(List<Tarefa> tarefas,Status staus)
        {
            return tarefas.Where(s => s.Status == staus).ToList();
        }

    }
}
