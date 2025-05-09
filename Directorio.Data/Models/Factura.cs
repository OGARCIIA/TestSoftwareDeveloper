using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Directorio.Data.Models;

public partial class Factura
{
    [Key]
    public int Id { get; set; }

    public int? PersonaId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Monto { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [ForeignKey("PersonaId")]
    [InverseProperty("Facturas")]
    public virtual Persona? Persona { get; set; }
}
