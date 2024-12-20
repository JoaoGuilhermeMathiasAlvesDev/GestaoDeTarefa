﻿using GestaoDeTarefa.Aplication.Models;
using GestaoDeTarefa.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Aplication.IServices
{
    public interface ITarefasServices
    {
        Task<IEnumerable<TarefasModels>> ObterTodos();
        Task<TarefasModels> ObterPorId(Guid id);
        Task adiconar(TarefasModels tarefas);
        Task Atualizar(TarefasModels tarefas);
        Task Deleta(Guid id);
        Task<IEnumerable<TarefasModels>> ObterPorStatus(Status status);
    }
}
