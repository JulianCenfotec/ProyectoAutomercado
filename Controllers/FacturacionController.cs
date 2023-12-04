using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Controllers
{
    [Route("api/Facturacion")]
    [ApiController]
    public class FacturacionController : Controller
    {

        private readonly IPersonaService<Facturacion> _FacturacionService;

        public FacturacionController(IPersonaService<Facturacion> facturacionService)
        {
            _FacturacionService = facturacionService;
        }
        [HttpGet]
        public async Task<List<Facturacion>> Get() =>
             await _FacturacionService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Facturacion>> Get(string Codigo)
        {
            var Facturacion = await _FacturacionService.GetAsync(Codigo);

            if (Facturacion == null)
            {
                return NotFound();
            }

            return Ok(Facturacion);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Facturacion newFacturacion)
        {
            await _FacturacionService.CreateAsync(newFacturacion);

            return CreatedAtAction(nameof(Get), new { id = newFacturacion._id }, newFacturacion);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string Codigo, Facturacion updatedFacturacion)
        {
            var Facturacion = await _FacturacionService.GetAsync(Codigo);

            if (Facturacion == null)
            {
                return NotFound();
            }

            updatedFacturacion._id = Facturacion._id;

            await _FacturacionService.UpdateAsync(Codigo, updatedFacturacion);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Facturacion = await _FacturacionService.GetAsync(id);

            if (Facturacion == null)
            {
                return NotFound();
            }

            await _FacturacionService.RemoveAsync(id);

            return NoContent();
        }
    }
}
