using Microsoft.EntityFrameworkCore;
using Papeleria.AccesoDatos.InterfacesRepositorios;
using Papeleria.AccesoDatos.PapeleriaCT;
using Papeleria.AccesoDatos.RepositoriosEF;
using Papeleria.LogicaAplicacion.CasosUso.Articulos;
using Papeleria.LogicaAplicacion.CasosUso.Clientes;
using Papeleria.LogicaAplicacion.CasosUso.IVA;
using Papeleria.LogicaAplicacion.CasosUso.Pedidos;
using Papeleria.LogicaAplicacion.CasosUso.Rols;
using Papeleria.LogicaAplicacion.CasosUso.Usuarios;
using Papeleria.LogicaAplicacion.ICasosUso.Articulos;
using Papeleria.LogicaAplicacion.ICasosUso.ICliente;
using Papeleria.LogicaAplicacion.ICasosUso.IPedidos;
using Papeleria.LogicaAplicacion.ICasosUso.IRol;
using Papeleria.LogicaAplicacion.ICasosUso.IUsuarios;
using Papeleria.LogicaAplicacion.ICasosUso.IVA;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Papeleria.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Articulos
            builder.Services.AddScoped<IRepositorioArticulos,RepositorioArticulosEF > ();
            builder.Services.AddScoped<ICUAgregarArticulo, CUAgregarArticulo>();
            builder.Services.AddScoped<ICUObtenerArticulos, CUObtenerArticulos>();
            builder.Services.AddScoped<ICUGetArticuloById, CUGetArticuloById>();
            builder.Services.AddScoped<ICUGetPrecioArticuloById, CUGetPrecioArticuloById>();
            builder.Services.AddScoped<ICUActualizarArticulo, CUActualizarArticulo>();
            //Usuarios
            builder.Services.AddScoped<IRepositorioUsuarios,RepositorioUsuariosEF > ();
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUObtenerUsuarios, CUObtenerUsuarios>();
            builder.Services.AddScoped<ICUObtenerUsuarioByEmail, CUObtenerUsuarioByEmail>();
            builder.Services.AddScoped<ICUActualizarUsuario, CUActualizarUsuario>();
            builder.Services.AddScoped<ICUEliminarUsuario, CUEliminarUsuario>();
            builder.Services.AddScoped<ICUIniciarSesion, CUIniciarSesion>();
            //Roles
            builder.Services.AddScoped<IRepositorio<Rol>, RepositorioRolesEF > ();
            builder.Services.AddScoped<ICUObtenerRoles, CUObtenerRoles>();
            builder.Services.AddScoped<ICUObtenerRol, CUObtenerRol>();
            //Pedidos
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidosEF > ();
            builder.Services.AddScoped<ICUGetAllPedidos, CUGetAllPedidos>();
            builder.Services.AddScoped<ICUAddPedidoToDatabase, CUAddPedidotoDatabase>();
            builder.Services.AddScoped<ICUGetPedidoLast, CUGetPedidoLast>();
            builder.Services.AddScoped<ICUGetPedidosByFechaEmision, CUGetPedidosByFechaEmision>();
            builder.Services.AddScoped<ICUAnularPedido, CUAnularPedido>();
            //TipoPedidos
            builder.Services.AddScoped<IRepositorioTipoPedido, RepositorioTipoPedido>();
            builder.Services.AddScoped<ICUObtenerTipoPedidos, CUObtenerTipoPedidos>();
            builder.Services.AddScoped<ICUGetTipoPedidoById, CUGetTipoPedidoById>();
            //Clientes
            builder.Services.AddScoped<IRepositorioClientes, RepositorioClientesEF > ();
            builder.Services.AddScoped<ICUObtenerClientes, CUObtenerClientes>();
            builder.Services.AddScoped<ICUGetClienteByRazonSocial, CUGetClienteByRazonSocial>();
            builder.Services.AddScoped<ICUGetClienteById, CUGetClienteById>();
            builder.Services.AddScoped<ICUGetClientesByMonto, CUGetClientesByMonto>();
            //IVA
            builder.Services.AddScoped<IRepositorioIVA, RepositorioIvaEF> ();
            builder.Services.AddScoped<ICUOBtenerIVA, CUObtenerIva>();


            //Iniciar Sesion
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });

            var configuracion = new ConfigurationBuilder();
            string cadenaConexion = 
                configuracion.AddJsonFile("appsettings.json").
Build().GetConnectionString("Connection");
            builder.Services.AddDbContext<PapeleriaContext>(options =>
                options.UseSqlServer(cadenaConexion));


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
            app.UseSession();
            app.Run();
        }
    }
}
