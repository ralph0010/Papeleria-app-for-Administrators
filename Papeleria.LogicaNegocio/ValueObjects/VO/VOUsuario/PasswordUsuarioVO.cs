using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones.UsuarioException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.IVO.IVOUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.VOUsuario
{
    [Owned]
    [Index(("Password"),"PasswordEncriptada")]
    public class PasswordUsuarioVO : IValidable, IPasswordUsuarioVO
    {
        public string Password { get; set; }
        public string PasswordEncriptada { get; set; }
       
        public PasswordUsuarioVO(string password)
        {
            Password = password;
            Validar();
            
        }
        public PasswordUsuarioVO() { }
        //Validar Password
        public void Validar()
        {
            ValidarMinimo();
            ValidarMayusMinus();
            ValidarPuntuacionYDigito();
        }
        //Valida si contiene un minimo de seisCaracteres
        private bool MinimoSeis()
        {
        
            return Password.Length >= 6;
        }
        //Valida si contiene minimo una letra mayuscula
        private bool MinMayuscula()
        {
            bool retorno = false;
            for (int i = 0; i < Password.Length && retorno == false; i++)
            {
                char c = Password[i];
                if (char.IsUpper(c))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        //Valida si contiene minimo una letra minuscula
        private bool MinMinuscula()
        {
            bool retorno = false;
            for (int i = 0; i < Password.Length && retorno == false; i++)
            {
                char c = Password[i];
                if (char.IsLower(c))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        //Valida si contiene digito 
        private bool MinDigito()
        {
            bool retorno = false;
            for (int i = 0; i < Password.Length && retorno == false; i++)
            {
                char c = Password[i];
                if (char.IsDigit(c))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        //Valida si contiene un caracter de puntuacion
        private bool MinCharPuntuacion()
        {
            bool retorno = false;
            for (int i = 0; i < Password.Length && retorno == false; i++)
            {
                char c = Password[i];
                if (char.IsPunctuation(c))
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        //Valida metodos privados, sino muestra una exception
        public void ValidarMinimo()
        {
            if (!MinimoSeis())
            {
                throw new PasswordInvalidaException("Error, la contraseña debe contener un minimo de seis caracteres");
            };
        }
        //Valida la Mayusculas y minusculas, mostrando una exception
        public void ValidarMayusMinus()
        {
            if (!MinMayuscula() || !MinMinuscula())
            {
                throw new PasswordInvalidaException("Error, la contrseña debe contener una mayúscula y una minúscula");
            }
        }
        //Valida si posee numero y signo de puntuacion, en caso contrario tira una exception
        public void ValidarPuntuacionYDigito()
        {
            if (!MinCharPuntuacion())
            {
                throw new PasswordInvalidaException("Error, la contraseña debe contener mínimo un valor de puntuación ('!', ',', ';', '.')");
            }
            if (!MinDigito())
            {
                throw new PasswordInvalidaException("Error, la contraseña debe contener mininmo un digito");
            }
        }
    }
}
