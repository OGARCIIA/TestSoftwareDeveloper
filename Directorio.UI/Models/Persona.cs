using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio.UI.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Identificacion { get; set; }

        public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
    }

}
