using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.ValuePedido
{
    [Owned]
    public class ClaseIVA
    {
        public int Id { get; set; }
        private double _valor = 0.22;
        public double Valor { get=>_valor; set=>_valor =value; }
        public ClaseIVA()
        {
        }
        
        

    }

}

