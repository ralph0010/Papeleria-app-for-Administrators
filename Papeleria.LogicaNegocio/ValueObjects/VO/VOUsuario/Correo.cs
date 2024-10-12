using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones.UsuarioException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.VOUsuario
{
    [Owned]
    [Index(nameof(Email), IsUnique = true)]
    public record Correo : IValidable
    {
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; init; }

        public Correo(string correo)
        {
            Email = correo.ToLower();
            Validar();
        }
        public Correo() { }


        //Valida
        public void Validar()
        {
            MailNull();
            Contain();
        }
        //Valida que el email recibido no sea null
        private void MailNull()
        {
            if (Email == null && string.IsNullOrEmpty(Email))
            {
                throw new EmailInvalidoException("Error, el email no puede estar vacío");
            }
        }
        //Verifica que el email contenga un @
        private void Contain()
        {
            if (!Email.Contains("@"))
            {
                throw new EmailInvalidoException("El email debe contener un @: \n Rafael@example.com");
            }
            if (ContieneMasDeUnArroba())
            {
                throw new EmailInvalidoException("Error solo puede contener un @");
            }

        }
        //Verifica que solo contenga un @
        private bool ContieneMasDeUnArroba()
        {
            int contador = 0;
            char letra = ' ';
            bool contieneMas= false;
            for (int i = 0; i < Email.Length; i++)
            {
                
                letra = Email[i];
                if (letra=='@')
                {
                    contador++;
                }
                if (contador > 1)
                {
                    contieneMas = true;
                    break;
                }
            }
            return contieneMas;

        }
        

    }

}

