using GestaoDeTarefa.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Infresturua.Ioc.BancoDeDados
{
    public static class ConfiguracaoBancoDeDados
    {
        public static void Conexao(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddDbContext<TarefaContexto>(options => options.UseSqlServer(connectionString));
        }
    }
}
