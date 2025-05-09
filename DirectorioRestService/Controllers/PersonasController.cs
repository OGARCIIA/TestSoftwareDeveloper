using Directorio.Data.Models;
using Directorio.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DirectorioRestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepository _repo;

        public PersonasController(IPersonaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_repo.GetById(id));

        [HttpPost]
        public IActionResult Add(Persona persona)
        {
            if (string.IsNullOrEmpty(persona.Nombre) || string.IsNullOrEmpty(persona.ApellidoPaterno) || string.IsNullOrEmpty(persona.Identificacion))
                return BadRequest("Campos obligatorios");

            _repo.Add(persona);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }

}
