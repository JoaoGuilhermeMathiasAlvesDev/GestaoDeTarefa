using GestaoDeTarefa.Data.Data;
using GestaoDeTarefa.Dominio.Entitidades;
using GestaoDeTarefa.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Data.Reposiorios
{
    public class TarefasRepository : ITarefaRepository
    {
        private readonly TarefaContexto _tafaContexto;

        public TarefasRepository(TarefaContexto tafaContexto)
        {
            _tafaContexto = tafaContexto;
        }

        public async Task adicionarTarefa(Tarefa tarefa)
        {
            await _tafaContexto.tarefas.AddAsync(tarefa);

            await _tafaContexto.SaveChangesAsync();
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            _tafaContexto.tarefas.Update(tarefa);
           await _tafaContexto.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var tarefa = await _tafaContexto.tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _tafaContexto.tarefas.Remove(tarefa);
               await _tafaContexto.SaveChangesAsync();
            }
        }

        public async Task<Tarefa> ObterPorId(Guid id)
        {
            return await _tafaContexto.tarefas.FindAsync(id);
        }

        public async Task<List<Tarefa>> ObterTodos()
        {
            return await _tafaContexto.tarefas.ToListAsync();
        }
    }
}
