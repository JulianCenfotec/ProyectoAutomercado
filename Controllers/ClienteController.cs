using ProyectoDiseñoSoft.Fabrica;
using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDiseñoSoft.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClienteController : Controller
    {
        private readonly IPersonaService<Cliente> _ClienteService;

        public ClienteController(IPersonaService<Cliente> clienteService)
        {
            _ClienteService = clienteService;
        }

        [HttpGet]
        public async Task<List<Cliente>> Get() =>
            await _ClienteService.GetAsync();

        [HttpGet("{id:length(12)}")]
        public async Task<ActionResult<Cliente>> Get(string id)
        {
            var user = await _ClienteService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente newCliente)
        {
            await _ClienteService.CreateAsync(newCliente);

            return CreatedAtAction(nameof(Get), new { id = newCliente._id }, newCliente);
        }

        [HttpPut("{id:length(12)}")]
        public async Task<IActionResult> Update(string id, Cliente updatedCliente)
        {
            var user = await _ClienteService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedCliente._id = user._id;

            await _ClienteService.UpdateAsync(id, updatedCliente);

            return NoContent();
        }

        [HttpDelete("{id:length(12)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _ClienteService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _ClienteService.RemoveAsync(id);

            return NoContent();
        }
    }
}

