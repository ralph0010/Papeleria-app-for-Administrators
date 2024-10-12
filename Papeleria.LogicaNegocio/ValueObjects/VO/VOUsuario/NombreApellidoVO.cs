using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones.UsuarioException;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects.IVO.IVOUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects.VO.VOUsuario
{
    [Owned]
    [Index("Nombre","Apellido")]
    public class NombreApellidoVO: IValidable, INombreApellidoVO
    {
        [Column("NombreUsuario")]
        public string Nombre {  get; set; }
        [Column("ApellidoUsuario")]
        public string Apellido { get; set; }

        public NombreApellidoVO(string nombre, string apellido) 
        {
            Nombre = nombre;
            Apellido = apellido;
            Validar();
        }


        //Ejecuta metodos de validacion
        public void Validar()
        {
            EsVacio();
            ValidarCharInicioYFinal();
            ValidarSiCumpleReglas();
        }
        //Valida si no llegan datos al nombre y apellido
        private void EsVacio()
        {
            if(string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(Nombre))
            {
                throw new NombreApellidoException("Error, Nombre y Apellido no pueden ser vacíos");
            }
        }
        //Retorna si la posicion contiene una letra
        private bool EsAlfabeticoPosition(string palabra, int position)
        {
            bool retorno = false;
            char c = palabra[position];
            if (char.IsLetter(c))
            {
                retorno = true;
            }
            return retorno;
        }
        //Valida el nombre y apellido el primer y ultimo caracter si contiene letra
        public void ValidarCharInicioYFinal()
        {
            if(!EsAlfabeticoPosition(Nombre,0) ||
                !EsAlfabeticoPosition(Nombre, Nombre.Length-1) || 
                !EsAlfabeticoPosition(Apellido, 0) || 
                !EsAlfabeticoPosition(Apellido, Apellido.Length -1))
            {
                throw new NombreApellidoException("Error, el inicio y el final del nombre y apellido deben ser de un caracter alfabetico");
            }
        }
        //Valida caracteres de nombre y apellido con el metodo corrrespondiente
        public void ValidarSiCumpleReglas()
        {
            if(!CumpleLetra(Nombre) || !CumpleLetra(Apellido))
            {
                throw new NombreApellidoException("El nombre solo de contener letras, guion del medio, espacio y apostrofe");
            }
        }
        //Valida si contienes alguna de los caracteres especificados
        public bool CumpleLetra(string palabra)
        {
            bool retorno = true;
            char c ;
            for(int i = 0; i < palabra.Length && retorno == true; i++)
            {
                c= palabra[i];
                if(!char.IsLetter(c) && c != ' ' && c!= '-' && c!= '\'')
                {
                    retorno= false;
                }
            }
            return retorno;
        }
    }
}
