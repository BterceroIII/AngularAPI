﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Empleado>? EmpleadosReferencia { get; set; }
    }
}
