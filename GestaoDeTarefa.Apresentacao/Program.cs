using GestaoDeTarefa.Infresturua.Ioc.BancoDeDados;
using GestaoDeTarefa.Infresturua.Ioc.ConfiguracaoLogin;
using GestaoDeTarefa.Infresturua.Ioc.InjeicaoDeIdepencia;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Conexao(builder.Configuration);
        builder.Services.Idenpendencia(builder.Configuration);
        builder.Services.Autenticacao(builder.Configuration);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddAuthorization();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(name: "default", pattern: "{controller=Login}/{action=Login}/{id?}");
        app.Run();
    }
}