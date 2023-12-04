using ProyectoDiseñoSoft.Fabrica;
using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDiseñoSoft.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    public class ProductoController : Controller
    {
        private readonly IPersonaService<Producto> _ProductoService;

        public ProductoController(IPersonaService<Producto> productoService)
        {
            _ProductoService = productoService;
        }

        [HttpGet]
        public async Task<List<Producto>> Get() =>
            await _ProductoService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Producto>> Get(string id)
        {
            var user = await _ProductoService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Producto newProducto)
        {
            await _ProductoService.CreateAsync(newProducto);

            return CreatedAtAction(nameof(Get), new { id = newProducto._id }, newProducto);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Producto updatedProducto)
        {
            var user = await _ProductoService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedProducto._id = user._id;

            await _ProductoService.UpdateAsync(id, updatedProducto);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _ProductoService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _ProductoService.RemoveAsync(id);

            return NoContent();
        }
    }
}