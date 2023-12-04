using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios;
using Microsoft.AspNetCore.Mvc;
using ProyectoDiseñoSoft.Fabrica;

namespace ProyectoDiseñoSoft.Controllers
{
    [ApiController]
    [Route("api/Compras")]
    public class ComprasController : Controller
    {

        private readonly IPersonaService<Compras> _CompraService;

        public ComprasController(IPersonaService<Compras> comprasService)
        {
            _CompraService = comprasService;
        }
        [HttpGet]
        public async Task<List<Compras>> Get() =>
            await _CompraService.GetAsync();

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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
