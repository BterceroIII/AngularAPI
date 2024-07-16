using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int IdDepartamento { get; set; }
        public Departamento? Departamento { get; set; }
        public decimal Sueldo { get; set; }
        public DateOnly FechaContrato { get; set; }
        public bool Activo { get; set; }
    }
}
