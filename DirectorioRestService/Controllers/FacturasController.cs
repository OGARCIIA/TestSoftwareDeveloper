using Directorio.Data.Models;
using Directorio.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DirectorioRestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaRepository _repo;

        public FacturasController(IFacturaRepository repo)
        {
            _repo = repo;
        }

        // GET: api/facturas
        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        // GET: api/facturas/persona/1
        [HttpGet("persona/{personaId}")]
        public IActionResult GetByPersona(int personaId)
        {
            var facturas = _repo.GetByPersonaId(personaId);
            return Ok(facturas);
        }

        // POST: api/facturas
        [HttpPost]
        public IActionResult Add(Factura factura)
        {
            if (factura.PersonaId <= 0 || factura.Monto <= 0)
                return BadRequest("PersonaId y Monto son obligatorios");

            _repo.Add(factura);
            return Ok();
        }
    }
}
