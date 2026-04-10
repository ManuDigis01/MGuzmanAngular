using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    [Keyless]
    public class RolGetAllDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
