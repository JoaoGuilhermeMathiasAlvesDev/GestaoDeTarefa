using GestaoDeTarefa.Aplication.IServices;
using GestaoDeTarefa.Aplication.Services;
using GestaoDeTarefa.Data.Reposiorios;
using GestaoDeTarefa.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Infresturua.Ioc.InjeicaoDeIdepencia
{
    public static class InjeicaoDeIdependencia
    {
        public static void Idenpendencia(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ITarefasServices,TarefaServicos>();

            services.AddScoped<ITarefaRepository, TarefasRepository>();

            services.AddHttpClient<ApiService>();
        }


    }
}
