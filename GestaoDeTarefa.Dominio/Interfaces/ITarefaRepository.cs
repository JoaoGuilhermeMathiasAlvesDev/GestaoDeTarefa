using GestaoDeTarefa.Dominio.Entitidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Dominio.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> ObterTodos();
        Task<Tarefa> ObterPorId(Guid id);

        Task adicionarTarefa(Tarefa tarefa);

        void Atualizar(Tarefa tarefa);

        Task Deletar (Guid id);

    }
}
