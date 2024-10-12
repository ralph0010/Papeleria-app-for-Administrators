
using Microsoft.EntityFrameworkCore;
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.AccesoDatos.RepositoriosEF;
using Papeleria.LogicaAplicacion.CasosUso.Articulos;
using Papeleria.LogicaAplicacion.CasosUso.Pedidos;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;

namespace Papeleria.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Pedido
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidosEF>();
            builder.Services.AddScoped<ICUObtenerPedidosAnulados, CUObtenerPedidosAnulados>();

            //Articulos
            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulosEF>();
            builder.Services.AddScoped<ICUObtenerArticulosOrdenadoParaDto, CUObtenerArticulosOrdenadosParaDto>();

            var configuracion = new ConfigurationBuilder();
            string cadenaConexion =
                configuracion.AddJsonFile("appsettings.json").
Build().GetConnectionString("Connection");
            builder.Services.AddDbContext<PapeleriaContext>(options =>
                options.UseSqlServer(cadenaConexion));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
