using Directorio.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio.Data.Repositories
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        void Add(Persona persona);
        void Delete(int id);
    }
}
