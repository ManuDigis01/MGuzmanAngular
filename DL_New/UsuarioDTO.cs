using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DL_New
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string UserName { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateOnly? FechaNacimiento { get; set; }

        public bool Estatus { get; set; }

        public int IdRol { get; set; }

        public string? NombreRol { get; set; }
    }
}
