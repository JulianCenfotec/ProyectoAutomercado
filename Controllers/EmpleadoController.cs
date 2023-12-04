using Microsoft.AspNetCore.Mvc;
using ProyectoDiseñoSoft.Modelos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDiseñoSoft.Servicios;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Controllers
{
    [Route("api/Empleados")]
    [ApiController]
    public class EmpleadoController : Controller
    {

        private readonly IPersonaService<Empleados> _EmpleadoService;

        public EmpleadoController(IPersonaService<Empleados> empleadoService)
        {
            _EmpleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<List<Empleados>> Get() =>
             await _EmpleadoService.GetAsync();

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
