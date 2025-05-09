using Directorio.Data.Models;
using System.Collections.Generic;

namespace Directorio.Data.Repositories
{
    public interface IFacturaRepository
    {
        IEnumerable<Factura> GetAll();                     
        IEnumerable<Factura> GetByPersonaId(int personaId);
        void Add(Factura factura);                          
    }
}
