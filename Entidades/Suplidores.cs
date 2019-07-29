﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suplidores
    {
        [Key]
        public int CodigoSuplidor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string  Telefono { get; set; }
        public string RNC { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        public Suplidores()
        {
            CodigoSuplidor = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            RNC = string.Empty;
            FechaCreacion = DateTime.Now;
        }
    }
}
