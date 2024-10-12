using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades.CodigoComun;
using Papeleria.LogicaNegocio.Excepciones.ClienteException;
using Papeleria.LogicaNegocio.InterfacesEntidades;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.VOCliente
{
    [Owned]
    [Index(nameof(Calle), nameof(Numero), nameof(Ciudad), nameof(DistanciaPapeleria))]
    public record DireccionRecordVO : IValidable 
    {
        public string Calle { get; set; }

        public string Numero { get; set; }

        public string Ciudad { get; set; }

        public double DistanciaPapeleria { get; set; }
        public DireccionRecordVO(string calle, string numero, string ciudad, double distanciaPapeleria)
        {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
            DistanciaPapeleria = distanciaPapeleria;
            Validar();
        }
        //Ejecuta metodo de validacion
        public void Validar()
        {
            ValidarNumero();
        }
        //Si numero no es digito tira una exception
        private void ValidarNumero()
        {
            if (MetodosComun.NoEsDigito(Numero))
            {
                throw new DireccionNoValidaException("Error, " +
                    "el número de calle solo puede contener números");
            }
        }

    }

}

