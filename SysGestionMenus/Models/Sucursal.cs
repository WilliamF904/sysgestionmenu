using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionMenus.Models;

public partial class Sucursal
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Direccion { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? WhatsApp { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Correo { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Eslogan { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("IdSucursal")]
    public virtual ICollection<Usuario> IdUsuario { get; set; } = new List<Usuario>();
}
