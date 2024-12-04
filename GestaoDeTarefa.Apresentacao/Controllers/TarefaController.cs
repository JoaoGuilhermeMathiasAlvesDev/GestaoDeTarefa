using GestaoDeTarefa.Aplication.IServices;
using GestaoDeTarefa.Aplication.Models;
using GestaoDeTarefa.Aplication.Services;
using GestaoDeTarefa.Dominio.Entitidades;
using GestaoDeTarefa.Dominio.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime;

namespace GestaoDeTarefa.Apresentacao.Controllers
{


    public class TarefaController : Controller
    {
        private readonly ITarefasServices _tarefasServices;

        public TarefaController(ITarefasServices tarefasServices)
        {
            _tarefasServices = tarefasServices;
        }



        #region view
        public async Task<IActionResult> Index([FromServices] ApiService apiService)
        {
            var token = HttpContext.Session.GetString("JWToken");
            var tarefas = await _tarefasServices.ObterTodos();
            return View(tarefas);
        }


        public IActionResult Adicionar()
        {
            return View();
        }


        public async Task<IActionResult> Atualizar(Guid id)
        {
            var tarefa = await _tarefasServices.ObterPorId(id);

            if (tarefa == null) return NotFound();

            return View(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorStatus(Status? status)
        {
            IEnumerable<TarefasModels> tarefas;
            if (status.HasValue)
            {
                tarefas = await _tarefasServices.ObterPorStatus(status.Value);
            }
            else
            {
                tarefas = await _tarefasServices.ObterTodos();
            }
            return View("Index", tarefas);
        }



        #endregion
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _tarefasServices.Deleta(id);

            return RedirectToAction("Index");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            var tarefa = await _tarefasServices.ObterPorId(id);

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult> AtualizarStatus(Guid Id, Status status)
        {
            var tarefa = await _tarefasServices.ObterPorId(Id);
            if (tarefa == null)
                return NotFound();


            tarefa.Status = status;

            await _tarefasServices.Atualizar(tarefa);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<ActionResult> Atualizar(TarefasModels tarefa)
        {
            if (tarefa == null)
            {
                throw new ArgumentNullException(nameof(tarefa));
            }

            await _tarefasServices.Atualizar(tarefa);
            return RedirectToAction("Index"); ;
        }

        [HttpPost]
        public async Task<ActionResult<TarefasModels>> Adicionar(TarefasModels tarefas)
        {
            if (tarefas is null)
            {
                throw new ArgumentNullException(nameof(tarefas));
            }

            _tarefasServices.adiconar(tarefas);
            return RedirectToAction("Index");
        }

    }
}
