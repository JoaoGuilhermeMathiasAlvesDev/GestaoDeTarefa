using GestaoDeTarefa.Dominio.Entitidades;
using GestaoDeTarefa.Dominio.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Data.Data
{
    public class TarefaContexto : DbContext
    {
        public TarefaContexto(DbContextOptions<TarefaContexto> options)
            :base(options) { }


        public DbSet<Tarefa> tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>(T =>
            {
                T.HasKey(T => T.Id);
                T.Property(T=> T.Status).HasDefaultValue(Status.Pendente);
            });
        }
    }
}
