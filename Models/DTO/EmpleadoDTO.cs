using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int IdDepartamento { get; set; }
        public decimal Sueldo { get; set; }
        public DateOnly FechaContrato { get; set; }
        public bool Activo { get; set; }
        public string? NombreDepartamento { get; set; }
    }
}
