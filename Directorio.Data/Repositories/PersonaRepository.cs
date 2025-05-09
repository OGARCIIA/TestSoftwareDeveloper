using Directorio.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio.Data.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly TestDbContext _context;

        public PersonaRepository(TestDbContext context)
        {
            _context = context;
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var persona = _context.Personas.Find(id);
            if (persona != null)
            {
                var facturas = _context.Facturas.Where(f => f.PersonaId == id);
                _context.Facturas.RemoveRange(facturas);
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Persona> GetAll() => _context.Personas.ToList();

        public Persona GetById(int id) => _context.Personas.Find(id);
    }
}
