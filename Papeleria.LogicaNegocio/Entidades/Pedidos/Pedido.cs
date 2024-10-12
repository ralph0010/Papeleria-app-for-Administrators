using System.Collections.Generic;
using System;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using Papeleria.LogicaNegocio.Excepciones.PedidosException;
using Papeleria.LogicaNegocio.Entidades.CodigoComun;

namespace Papeleria.LogicaNegocio.Entidades.Pedidos
{
    public class Pedido : IEntity<Pedido>, IValidable, IPedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemArticulo> Articulos { get; set; }
        public double IVA { get; set; }
        public TipoPedido Tipo { get; set; }
        public double Recargo {  get; set; }
        public FechaPedido Fecha { get; set; }

        public bool EstaAnulado { get; set; }
        public double PrecioTotalSinIva { get; set; } = 0;
        public double PrecioTotalConIva { get; set; } = 0;

        public Pedido(Cliente cliente, List<ItemArticulo> articulos, TipoPedido tipo, FechaPedido fecha, double valorIva) 
        {
            Cliente = cliente;
            Articulos = articulos;
            Tipo = tipo;
            EstaAnulado = false;
            Fecha=fecha;
            IVA = valorIva;
            Recargo = Tipo.CalcularRecargo();
            PrecioTotalSinIva = CalcularTotalSinIva();
            PrecioTotalConIva = CalcularTotalConIva();
            Validar();
            enviarKm();
            EnviarDiasATipo();
            
            Tipo.Validar();
            Fecha.Validar();

        }
        public Pedido() { }
        //Ejecuta los metodos de validaciones
        public void Validar()
        {
            ValidarCantidadArticulos();
            ValidarNullCliente();
            ValidarNullFecha();
            ValidarNullTipoPedido();
            ValidarPrecioTotales();            
        }
        //Envia la cantidad de Km desde el cliente hasta el TipoDePedido 
        private void enviarKm()
        {
            Tipo.Km = Cliente.Direccion.DistanciaPapeleria;
        }
        //Envia la cantidad de dias de envia para el objeto TipoDePedido
        private void EnviarDiasATipo()
        {
            Tipo.DiasEntrega = Fecha.DiasDiferencia;
        }
        //Metodo para calcular el total sin iva
        public double CalcularTotalSinIva()
        {
            if (PrecioTotalSinIva > 0)
            {
                return PrecioTotalSinIva;
            }
            double total = 0;
            foreach(ItemArticulo item in Articulos)
            {
                total += item.CalcularPrecioTotalItem();
            }
            if (Recargo > 0) 
            {
                total *=  (1+Recargo);
            }
            return total;
        }
        //Metodo para calcular el total con el iva
        public double CalcularTotalConIva()
        {
            if(PrecioTotalConIva > 0)
            {
                return PrecioTotalConIva;
            }
            return CalcularTotalSinIva() * (1+(IVA));
        }
        //Validar que el cliente no sea null
        private void ValidarNullCliente()
        {
            if(Cliente == null)
            {
                throw new PedidoException("Error,cliente no válido para el pedido");
            }
        }
        //Validar que el objeto fecha no sea null
        private void ValidarNullFecha()
        {
            if(Fecha == null)
            {
                throw new PedidoException("Error, Fecha no válida para el pedido");
            }
        }
        //Validar que el tipo de pedido no sea null
        private void ValidarNullTipoPedido()
        {
            if(Tipo == null)
            {
                throw new PedidoException("Error, el tipo de pedido es inválido");
            }
        }
       //Valida que exista por lo menos un articulo
        private void ValidarCantidadArticulos()
        {
            if (Articulos.Count < 1)
                throw new PedidoException("Error, no hay articulos para el pedido");
        }
        //Valida que los precios no sean menor a 1
        private void ValidarPrecioTotales()
        {
            if (PrecioTotalSinIva < 1 || PrecioTotalConIva < 1)
                throw new PedidoException("Error al calcular el total");
        }
        
        
        
        //Verifica si se puede anular el pedido
        public bool SePuedeAnularPedido()
        {
            return DateTime.Now.Date < Fecha.FechaEntrega.Date;
            
        }
       
    }

}

