using System;
using System.Collections.Generic;

namespace DL_New;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string UserName { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public bool Estatus { get; set; }
}
