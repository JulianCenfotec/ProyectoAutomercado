using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios;
using Microsoft.AspNetCore.Mvc;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Controllers
{
    [ApiController]
    [Route("api/grupos")]
    public class OrdenCompraController : Controller
    {
        private readonly IPersonaService<OrdenCompra> _OrdenCompraService;

        public OrdenCompraController(IPersonaService<OrdenCompra> ordenCompraService)
        {
            _OrdenCompraService = ordenCompraService;
        }
        [HttpGet]
        public async Task<List<OrdenCompra>> Get() =>
            await _OrdenCompraService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<OrdenCompra>> Get(string id)
        {
            var grupo = await _OrdenCompraService.GetAsync(id);

            if (grupo is null)
            {
                return NotFound();
            }

            return grupo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdenCompra newOrdenCompra)
        {
            await _OrdenCompraService.CreateAsync(newOrdenCompra);

            return CreatedAtAction(nameof(Get), new { id = newOrdenCompra._id }, newOrdenCompra);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, OrdenCompra updatedOrdenCompra)
        {
            var ordenCompra = await _OrdenCompraService.GetAsync(id);

            if (ordenCompra is null)
            {
                return NotFound();
            }

            updatedOrdenCompra._id = ordenCompra._id;

            await _OrdenCompraService.UpdateAsync(id, updatedOrdenCompra);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var grupo = await _OrdenCompraService.GetAsync(id);

            if (grupo is null)
            {
                return NotFound();
            }

            await _OrdenCompraService.RemoveAsync(id);

            return NoContent();
        }
    }
}
