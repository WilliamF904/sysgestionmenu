using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionMenus.Models;

public partial class Producto
{
    [Key]
    public int Id { get; set; }

    public int IdCategoria { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Imagen { get; set; }

    public byte Estatus { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("Producto")]
    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<Puntaje> Puntaje { get; set; } = new List<Puntaje>();

    [ForeignKey("IdProducto")]
    [InverseProperty("IdProducto")]
    public virtual ICollection<Menu> IdMenu { get; set; } = new List<Menu>();
}
