using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades.MovimientoStock;
using Papeleria.LogicaNegocio.Entidades.MovimientoStock.ClasesPorTipoMovimiento;
using Papeleria.LogicaNegocio.Entidades.Pedidos;
using Papeleria.LogicaNegocio.Entidades.Usuarios;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.PapeleriaCT
{
    public class PapeleriaContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> rols { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<TipoPedido> TipoPedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
        public DbSet<MovimientosStock> MovimientosStocks { get; set; }
        public DbSet<DefinirTipo> DefinirTipos { get; set; }
        public DbSet<ClaseIVA> iva { get; set; }


        public PapeleriaContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //Inserto en la base de datos el rol de Administrador y lo que lo identifica
            modelBuilder.Entity<Rol>()
                .HasDiscriminator<int>("Id")
                .HasValue<Administrador>(1).
                HasValue<EncargadoDeposito>(2);

            modelBuilder.Entity<Administrador>().HasData(
              new Administrador { Id = 1, TipoRol = "Administrador" });
            modelBuilder.Entity<EncargadoDeposito>().HasData(
                new EncargadoDeposito { Id = 2, TipoRol = "EncargadoDeposito" });


            //Inserto en la base de datos los dos tipos de pedidos y asigno el id identificatorio
            modelBuilder.Entity<TipoPedido>()
                .HasDiscriminator<int>("Id")
                .HasValue<PedidoComun>(1)
                .HasValue<PedidoExpress>(2);
            modelBuilder.Entity<PedidoComun>().HasData(new PedidoComun { Id = 1, Tipo = "PedidoComun" });
            modelBuilder.Entity<PedidoExpress>().HasData(new PedidoExpress { Id = 2, Tipo = "PedidoExpres" });
            //Indico la relacion de pedidos con los itemArticulos en el cual pedido tiene muchos items y los items solo puede pertenecer a un pedido
            modelBuilder.Entity<Pedido>().HasMany(p => p.Articulos).WithOne();
            //Inserto el dato de la clase iva en la base de datos
            modelBuilder.Entity<ClaseIVA>().HasData(new ClaseIVA { Id = 1, Valor = 0.22 });

            //Movmientos stock
            modelBuilder.Entity<DefinirTipo>()
                .HasDiscriminator<int>("Id")
                .HasValue<AumentoStock>(AumentoStock.RetornarId())
                .HasValue<ReduccionStock>(ReduccionStock.RetornarId())
                .HasValue<Traslado>(Traslado.RetornarId());

            
            modelBuilder.Entity<AumentoStock>().HasData(new AumentoStock
            {
                Id = AumentoStock.RetornarId(),
                TipoMovimiento = AumentoStock.RetotornarTipoMovimiento()
            });

            modelBuilder.Entity<ReduccionStock>().HasData(new ReduccionStock { 
                Id = ReduccionStock.RetornarId(),
                TipoMovimiento = ReduccionStock.RetotornarTipoMovimiento(),
            });

            modelBuilder.Entity<Traslado>().HasData(new Traslado
            {
                Id = Traslado.RetornarId(),
                TipoMovimiento = Traslado.RetotornarTipoMovimiento()
            });

            modelBuilder.Entity<MovimientosStock>().HasOne(m=> m.TipoMovimiento).WithMany();
        }
    }
}
