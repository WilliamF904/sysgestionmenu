using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionMenus.Models;

public partial class Menu
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    [ForeignKey("IdMenu")]
    [InverseProperty("IdMenu")]
    public virtual ICollection<Producto> IdProducto { get; set; } = new List<Producto>();
}
