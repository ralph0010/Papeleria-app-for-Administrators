using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades.Pedidos
{
    public abstract class TipoPedido: IValidable
    {
        [Key]
        public abstract int Id { get; set; }
        private string _tipo { get; set; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        [NotMapped]
        public int DiasEntrega { get; set; }
        [NotMapped]
        public double Km {  get; set; }
        public TipoPedido() { }
        public TipoPedido(string tipoPedido)
        {
            _tipo = tipoPedido;
        }
        public TipoPedido(int diasEntrega, double km)
        {
            DiasEntrega=diasEntrega;
            double Km = km;
            Validar();
        }
        //Pedira Calcular el recargo correspondiente
        public abstract double CalcularRecargo();
        //Pedira metodo/s de validar
        public abstract void Validar();
        
        
    }
}
