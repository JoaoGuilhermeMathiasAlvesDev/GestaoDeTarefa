using GestaoDeTarefa.Aplication.IServices;
using GestaoDeTarefa.Aplication.Models;
using GestaoDeTarefa.Dominio.Entitidades;
using GestaoDeTarefa.Dominio.Enum;
using GestaoDeTarefa.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Aplication.Services
{
    public class TarefaServicos : ITarefasServices
    {
        private readonly ITarefaRepository _repository;

        public TarefaServicos(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task adiconar(TarefasModels tarefas)
        {
            try
            {
                if (tarefas == null)
                {
                    throw new ArgumentNullException("Propiedade não pode ser null");
                }

                Tarefa tarefa = new Tarefa(tarefas.Nome, tarefas.Descricao, tarefas.Status);
                await _repository.adicionarTarefa(tarefa);

            }
            catch (Exception e)
            {

                throw new Exception("Ocorreu um erro tente novamente.", e);
            }
        }

        public async Task Atualizar(TarefasModels tarefas)
        {
            if (tarefas == null)
            {
                throw new ArgumentNullException("Não pode ser vazio ou null.");
            }

            var tarefa = await _repository.ObterPorId(tarefas.Id);

            tarefa.Atualizar(tarefas.Nome, tarefas.Descricao, tarefas.Status, tarefas.DataConclusao);

            await _repository.Atualizar(tarefa);
        }

        public async Task Deleta(Guid id)
        {
            if (id.Equals(0))
            {
                throw new ArgumentException("Não pode ser vazio ou null.");
            }

            await _repository.Deletar(id);
        }

        public async Task<TarefasModels> ObterPorId(Guid id)
        {
            var result = await _repository.ObterPorId(id);

            if (result == null) return null;

            return new TarefasModels
            {
                Id = result.Id,
                Nome = result.Nome,
                Descricao = result.Descricao,
                Status = result.Status,
                DataCriacao = result.DataCriacao,
                DataConclusao = result.DataConclusao,
            };
        }

        public async Task<IEnumerable<TarefasModels>> ObterPorStatus(Status status)
        {
            var tarefas = await _repository.ObterTodos();

            var result = new Tarefa().obterPorStatus(tarefas.ToList(), status);
            return result.Select(t => new TarefasModels
            {
                Id = t.Id,
                Nome = t.Nome,
                Descricao = t.Descricao,
                Status = t.Status,
                DataCriacao = t.DataCriacao,
                DataConclusao = t.DataConclusao
            }).ToList();

        }

        public async Task<IEnumerable<TarefasModels>> ObterTodos()
        {
            var result = await _repository.ObterTodos();

            return result.Select(t => new TarefasModels
            {
                Id = t.Id,
                Nome = t.Nome,
                Descricao = t.Descricao,
                Status = t.Status,
                DataCriacao = t.DataCriacao,
                DataConclusao = t.DataConclusao
            }).ToList();
        }

    }
}
