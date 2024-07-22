using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _empleadoService.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            Empleado empleado = await _empleadoService.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo([FromBody] Empleado empleado)
        {
            await _empleadoService.AddAsync(empleado);
            return StatusCode(StatusCodes.Status200OK, new {message = "Empleado creado exitosamente"});
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Empleado empleado)
        {
            await _empleadoService.UpdateAsync(empleado);
            return StatusCode(StatusCodes.Status200OK, new { message = "Empleado editado exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _empleadoService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK, new { message = "Empleado Eliminado exitosamente" });
        }
    }
}
