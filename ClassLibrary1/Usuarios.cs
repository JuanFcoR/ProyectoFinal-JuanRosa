using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }


    }
}
