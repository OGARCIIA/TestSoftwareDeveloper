using Directorio.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio.Data.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly TestDbContext _context;

        public FacturaRepository(TestDbContext context)
        {
            _context = context;
        }

        public void Add(Factura factura)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges();
        }

        public IEnumerable<Factura> GetAll()
        {
            return _context.Facturas.ToList();
        }

        public IEnumerable<Factura> GetByPersonaId(int personaId)
        {
            return _context.Facturas.Where(f => f.PersonaId == personaId).ToList();
        }

    }

}
