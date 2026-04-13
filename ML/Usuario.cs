using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
  
        public class Usuario
        {

        public int IdUsuario { get; set; }

        public string UserName { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateOnly? FechaNacimiento { get; set; }

        public bool Estatus { get; set; }

        public ML.Role? Role { get; set; }

    }
    }


