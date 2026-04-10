using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    [Keyless]
    public class UsuarioGetByIdDTO
    {
        public int IdUsuario { get; set; }

        public string? UserName { get; set; }

        public string? UsuarioNombre { get; set; }

        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FechaNacimiento { get; set; }

        public string? Sexo { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        public bool Estatus { get; set; }

        public string? Curp { get; set; }

        public byte[]? Imagen { get; set; }

        public string? IdRol { get; set; }

        public string? RolNombre { get; set; }

        public string? Calle { get; set; }

        public string? NumeroInterior { get; set; }

        public string? NumeroExterior { get; set; }

        public int? IdColonia { get; set; }

        public string? ColoniaNombre { get; set; }

        public string? CodigoPostal { get; set; }

        public int? IdMunicipio { get; set; }

        public string? NombreMunicipio { get; set; }

        public int? IdEstado { get; set; }

        public string? EstadoNombre { get; set; }
    }

    }
