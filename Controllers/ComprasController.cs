using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDiseñoSoft.Controllers
{
    [ApiController]
    [Route("api/Compras")]
    public class ComprasController : ControllerBase
    {
        private readonly ComprasService _CompraService;

        public ComprasController(ComprasService carrreraService)
        {
            _CompraService = carrreraService;
        }

        [HttpGet]
        public async Task<List<Compras>> Get() =>
            await _CompraService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Compras>> Get(string id)
        {
            var user = await _CompraService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Compras newCompra)
        {
            await _CompraService.CreateAsync(newCompra);

            return CreatedAtAction(nameof(Get), new { id = newCompra._id }, newCompra);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Compras updatedCompra)
        {
            var Compra = await _CompraService.GetAsync(id);

            if (Compra is null)
            {
                return NotFound();
            }

            updatedCompra._id = Compra._id;

            await _CompraService.UpdateAsync(id, updatedCompra);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Compra = await _CompraService.GetAsync(id);

            if (Compra is null)
            {
                return NotFound();
            }

            await _CompraService.RemoveAsync(id);

            return NoContent();
        }
    }
}
