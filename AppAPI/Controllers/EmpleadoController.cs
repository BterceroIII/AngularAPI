using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services.Interface;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpleadoDTO>>> Lista()
        {
            var listaDTO = new List<EmpleadoDTO>();
            var listaDB = await _empleadoService.GetAllAsync();
            
            foreach (var item in listaDB)
            {
                listaDTO.Add(new EmpleadoDTO
                {
                    IdEmpleado = item.IdEmpleado,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    IdDepartamento = item.DepartamentoReferencia.IdDepartamento,
                    Departamento = item.DepartamentoReferencia.Nombre,
                    Sueldo = item.Sueldo,
                    FechaContrato = item.FechaContrato,
                    Activo = item.Activo

                });
            }

           
            return StatusCode(StatusCodes.Status200OK, listaDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmpleadoDTO>>> Obtener(int id)
        {
            var empleadoDB = await _empleadoService.GetByIdAsync(id);

            if (empleadoDB == null)
            {
                return NotFound();
            }

            var empleadoDTO = new EmpleadoDTO
            {
                IdEmpleado = empleadoDB.IdEmpleado,
                Nombre = empleadoDB.Nombre,
                Apellido = empleadoDB.Apellido,
                IdDepartamento = empleadoDB.DepartamentoReferencia.IdDepartamento,
                Departamento = empleadoDB.DepartamentoReferencia.Nombre,
                Sueldo = empleadoDB.Sueldo,
                FechaContrato = empleadoDB.FechaContrato,
                Activo = empleadoDB.Activo
            };

            return StatusCode(StatusCodes.Status200OK, empleadoDTO);
        }

        [HttpPost]
        [Route("Nuevo")]
        public async Task<ActionResult<EmpleadoDTO>> Nuevo( EmpleadoDTO empleadoDTO)
        {
            var empleadoDB = new Empleado
            {
                Nombre = empleadoDTO.Nombre,
                Apellido = empleadoDTO.Apellido,
                Sueldo = empleadoDTO.Sueldo,
                FechaContrato = empleadoDTO.FechaContrato,
                Activo = empleadoDTO.Activo,
                IdDepartamento = empleadoDTO.IdDepartamento
            };

            await _empleadoService.AddAsync(empleadoDB);
            return StatusCode(StatusCodes.Status200OK, new {message = "Empleado creado exitosamente"});
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<EmpleadoDTO>> Editar(EmpleadoDTO empleadoDTO)
        {
            if (empleadoDTO == null)
            {
                return BadRequest("EmpleadoDTO es requerido.");
            }

            var empleadoDB = await _empleadoService.GetByIdAsync(empleadoDTO.IdEmpleado);
            if (empleadoDB == null)
            {
                return NotFound($"Empleado con ID {empleadoDTO.IdEmpleado} no encontrado.");
            }

            // Actualizar los campos del empleado existente
            empleadoDB.Nombre = empleadoDTO.Nombre;
            empleadoDB.Apellido = empleadoDTO.Apellido;
            empleadoDB.Sueldo = empleadoDTO.Sueldo;
            empleadoDB.FechaContrato = empleadoDTO.FechaContrato;
            empleadoDB.Activo = empleadoDTO.Activo;
            empleadoDB.IdDepartamento = empleadoDTO.IdDepartamento;

            await _empleadoService.UpdateAsync(empleadoDB);
            return StatusCode(StatusCodes.Status200OK, new { message = "Empleado editado exitosamente" });
        }

        [HttpDelete("{id}")]
    
        public async Task<IActionResult> Eliminar(int id)
        {
            var empleadoDB = await _empleadoService.GetByIdAsync(id);
            if (empleadoDB is null) return NotFound("Empleado no encontrado");

            await _empleadoService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK, new { message = "Empleado Eliminado exitosamente" });
        }
    }
}
