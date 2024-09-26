using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionMenus.Models;

public partial class Puntaje
{
    [Key]
    public int Id { get; set; }

    public int Valor { get; set; }

    public int IdProducto { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("Puntaje")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
