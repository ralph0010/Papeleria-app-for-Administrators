using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades.CodigoComun;
using Papeleria.LogicaNegocio.Excepciones.ArticuloException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.ValueArticulo
{
    [Owned]
    [Index(nameof(Codigo), IsUnique = true)]
    public record CodigoBarras: IValidable
    {
        public string Codigo {  get; set; }

        public CodigoBarras(string codigo)
        {
            Codigo = codigo;
            Validar();
        }
        //Ejecutará metodos de validaciones
        public void Validar()
        {
            ValidarNumero();
            ValidarCantDigitos();
        }
        //Validará que codigo recibido sea unicamente numeros
        //Sino lanzará un mensaje de exception
        private void ValidarNumero()
        {
            if (MetodosComun.NoEsDigito(Codigo))
            {
                throw new CodigoArticuloException("Error, el código" +
                    " solo puede contener dígitos");
            }
            
        }
        //Validará que la cantidad de digitos sea 13, sino lanza un
        //mensjae de exception
        private void ValidarCantDigitos()
        {
            if(Codigo.Length != 13)
            {
                throw new CodigoArticuloException("Error, " +
                    "la cantidad de digitos tiene que ser 13");

            }
        }
         
    }
}
