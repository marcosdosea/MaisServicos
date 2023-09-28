using Core;
using Core.OrcamentoService;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace MaisServicosWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MaisServicosContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("MaisServicosConnection")));

            builder.Services.AddTransient<IClienteService, ClienteService>();
            builder.Services.AddTransient<IPrestadorService, PrestadorService>();
            builder.Services.AddTransient<IOrcamentoService, OrcamentoService>();
            builder.Services.AddTransient<IServicoService, ServicoService>();
            builder.Services.AddTransient<IAreaDeAtuacao, AreaDeAtuacaoService>();
            builder.Services.AddTransient<IAvaliarClienteService, AvaliarClienteService>();
            builder.Services.AddTransient<IServicoContratado, ServicoContratadoService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}