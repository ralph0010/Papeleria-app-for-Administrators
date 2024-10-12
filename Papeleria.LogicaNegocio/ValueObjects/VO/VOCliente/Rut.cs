using Papeleria.LogicaNegocio.InterfacesEntidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Excepciones.ArticuloException;
using Papeleria.LogicaNegocio.Entidades.CodigoComun;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.VOCliente
{
    [Owned]
    [Index(nameof(Digitos), IsUnique = true)]
    public record Rut: IValidable
    {
        public string Digitos { get; set; }
        
        public Rut(string digitos)
        {
            Digitos = digitos;
            Validar();
        }
        //Ejecuta metodos de validaciones
        public void Validar()
        {
            ValidarNumero();
            ValidarCantDigitos();
        }
       //Si no contiene digitos el rut lanza una exception
        private void ValidarNumero()
        {
            if (MetodosComun.NoEsDigito(Digitos))
            {
                throw new CodigoArticuloException("Error, el RUT" +
                    " solo puede contener dígitos");
            }

        }
        //Si cantidad de digitos no es 12 lanza una exception
        private void ValidarCantDigitos()
        {
            if (Digitos.Length != 12)
            {
                throw new CodigoArticuloException("Error, " +
                    "la cantidad de digitos tiene que ser 12");

            }
        }
    }
}
