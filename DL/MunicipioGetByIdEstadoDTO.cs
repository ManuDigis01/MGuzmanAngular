using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    [Keyless]
    public class MunicipioGetByIdEstadoDTO
    {
        public int IdMunicipio { get; set; }
        public string? Nombre { get; set; }

    }
}
