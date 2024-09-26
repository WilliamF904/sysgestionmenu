using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionMenus.Models;

public partial class Categoria
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
