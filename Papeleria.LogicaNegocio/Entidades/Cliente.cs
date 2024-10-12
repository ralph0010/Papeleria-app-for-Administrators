using Papeleria.LogicaNegocio.Excepciones.ClienteException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.VO.VOCliente;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Cliente :IValidable, IEntity<Cliente>, IEquatable<Cliente>
	{
        public int Id { get; set; }
        public Rut Rut { get; set; }

		public string RazonSocial { get; set; }

		public DireccionRecordVO Direccion { get; set; }
        

        public Cliente (Rut rut, string razonSocial, DireccionRecordVO direccion)
        {
            Rut = rut;
            RazonSocial = razonSocial;
            Direccion = direccion;
            Validar();
        }
        public Cliente() { }
        //Ejecuta metodos de validaciones
        public void Validar()
        {
            
            ValidarRazonSocial();
            
        }
        //Verifica que Razon Social no sea null o vacio
        private void ValidarRazonSocial()
        {
            if (string.IsNullOrEmpty(RazonSocial))
            {
                throw new ClienteException("Error, la Razón Social no puede ser un dato nulo");
            }
        }

        public bool Equals(Cliente? other)
        {
            return RazonSocial.Equals(other.RazonSocial);
        }
    }

}

