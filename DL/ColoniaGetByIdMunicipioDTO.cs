using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    [Keyless]
    public class ColoniaGetByIdMunicipioDTO
    {

        public int IdColonia { get; set; }
        public string? Nombre { get; set; }
    }
}
