using Papeleria.LogicaNegocio.Excepciones.PedidosException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;

namespace Papeleria.LogicaNegocio.Entidades.Pedidos
{
    public class PedidoExpress : TipoPedido
    {
        private int _id = 2;
        public override int Id { get => _id; set => _id=value; }

        private static int DiasMaxiomoEntrega = 5;

        public PedidoExpress() :base("PedidoExpres") 
        { }
        
        
        public override double CalcularRecargo()
        {
            double recargo = 0.1;
            if(base.DiasEntrega == 0)
            {
                recargo = 0.15;
            }
            return recargo;
        }
        //Ejecuta Metodo de validacion
        public override void Validar()
        {
            ValidarDiaEntrega();
        }
        //Si el dia de entrega es mayor a dia Maximo ejecuta una exception 
        private void ValidarDiaEntrega()
        {
            if (base.DiasEntrega > DiasMaxiomoEntrega)
            {
                throw new TipoPedidoException("Error, para un pedido express la fecha" +
                    " de entrega no puede ser mayor a 5 dias");
            }
        }
    }

}

