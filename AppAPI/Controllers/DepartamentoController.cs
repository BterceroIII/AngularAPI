using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Interface;
using Services.Service;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<DepartamentoDTO>>> Lista()
        {
            var listaDTO = new List<DepartamentoDTO>();
            var listaDB = await _departamentoService.GetAllAsync();

            foreach (var item in listaDB)
            {
                listaDTO.Add(new DepartamentoDTO
                {
                    IdDepartamento = item.IdDepartamento,
                    Nombre = item.Nombre

                });
            }


            return StatusCode(StatusCodes.Status200OK, listaDTO);
        }
    }
}
