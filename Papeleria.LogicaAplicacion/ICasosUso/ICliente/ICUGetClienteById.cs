﻿using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.ICasosUso.ICliente
{
    public interface ICUGetClienteById
    {
        //Obtiene un cliente mediante el id
        Cliente GetCliente(int id);
    }
}