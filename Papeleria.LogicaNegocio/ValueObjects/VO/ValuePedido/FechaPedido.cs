using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones.PedidosException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido
{
    [Owned]
    [Index(nameof(FechaEmision), nameof(FechaEntrega))]
    public class FechaPedido : IValidable
    {
        public DateTime FechaEmision { get; set; }

        public DateTime FechaEntrega { get; set; }
        [NotMapped]
        public int DiasDiferencia { get; set; } = 0;

        public FechaPedido(DateTime fechaEntrega)
        {
            FechaEmision =InsertFechaEmision();
            FechaEntrega = fechaEntrega.Date;
            Validar();
            DiasDiferencia = CalcularDiasDiferencia();
        }
        public FechaPedido() { }
        //Si La fecha de Entrega es mayor a la de emision(Hoy) lanza una exception
        public void Validar()
        {
            if(FechaEntrega < FechaEmision)
            {
                throw new FechaPedidoException("Error, la fecha de Entrega no puede ser menor a " +
                    "la fecha de hoy");
            }
        }
        //Resta los dias de diferencia entre la fecha de entrega y la de emision(hoy)
        public int CalcularDiasDiferencia()
        {
            if(DiasDiferencia > 0) 
            {
                return DiasDiferencia;
            }
            return (FechaEntrega.Date - FechaEmision.Date).Days;
        }
        //Verifica si la fecha de emision fue emitida primero (retorna la fecha inicial), sino retorna la fecha actual
        private DateTime InsertFechaEmision()
        {
            if(FechaEmision > DateTime.MinValue)
            {
                return FechaEmision;
            }
            else
            {
            return DateTime.Now.Date;

            }
        }

    }

}

