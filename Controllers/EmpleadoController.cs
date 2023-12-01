using Microsoft.AspNetCore.Mvc;
using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDiseñoSoft.Servicios;

namespace ProyectoDiseñoSoft.Controllers
{
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _EmpleadoService;

        public EmpleadoController(EmpleadoService EmpleadoService)
        {
            _EmpleadoService = EmpleadoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleados>>> Get()
        {
            var Empleados = await _EmpleadoService.GetAsync();
            return Ok(Empleados);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Empleados>> Get(string id)
        {
            var Empleado = await _EmpleadoService.GetAsync(id);

            if (Empleado == null)
            {
                return NotFound();
            }

            return Ok(Empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Empleados newEmpleado)
        {
            await _EmpleadoService.CreateAsync(newEmpleado);

            return CreatedAtAction(nameof(Get), new { id = newEmpleado._id }, newEmpleado);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Empleados updatedEmpleado)
        {
            var Empleado = await _EmpleadoService.GetAsync(id);

            if (Empleado == null)
            {
                return NotFound();
            }

            updatedEmpleado._id = Empleado._id;

            await _EmpleadoService.UpdateAsync(id, updatedEmpleado);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Empleado = await _EmpleadoService.GetAsync(id);

            if (Empleado == null)
            {
                return NotFound();
            }

            await _EmpleadoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
