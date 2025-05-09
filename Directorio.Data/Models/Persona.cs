using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Directorio.Data.Models;

public partial class Persona
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    public string ApellidoPaterno { get; set; } = null!;

    [StringLength(100)]
    public string? ApellidoMaterno { get; set; }

    [StringLength(50)]
    public string Identificacion { get; set; } = null!;

    [InverseProperty("Persona")]
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
