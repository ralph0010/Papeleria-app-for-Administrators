using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using Papeleria.LogicaNegocio.Excepciones.PedidosException;
namespace Papeleria.LogicaNegocio.Entidades.Pedidos
{
    public class PedidoComun : TipoPedido
    {
        private int _id = 1;
        public override int Id { get =>_id; set =>_id = value; }

        private static int DiasMinimoEntrega = 7;
        public PedidoComun():base("PedidoComun") 
        {

        }
        public override double CalcularRecargo()
        {
            double recargo = 0;
            if(base.Km > 100)
            {
                recargo = 0.5;
            }
            return recargo;
        }
        //Ejecuta metodo de validacion
        public override void Validar()
        {
            ValidarDiaEntrega();
        }
        //Si el dia de entrega es menor al dia minimo ejecuta una exception
        private void ValidarDiaEntrega()
        {
            if(base.DiasEntrega < DiasMinimoEntrega)
            {
                throw new TipoPedidoException("Error, la fecha de envío en el pedidos comunes" +
                    " no puede ser menor a una semana");
            }
        }
    }

}

