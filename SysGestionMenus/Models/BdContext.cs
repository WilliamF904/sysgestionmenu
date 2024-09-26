using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SysGestionMenus.Models;

public partial class BdContext : Microsoft.EntityFrameworkCore.DbContext
{
    public BdContext()
    {
    }

    public BdContext(DbContextOptions<BdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Menu> Menu { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Puntaje> Puntaje { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Sucursal> Sucursal { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0773CBB016");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menu__3214EC0701672425");

            entity.HasMany(d => d.IdProducto).WithMany(p => p.IdMenu)
                .UsingEntity<Dictionary<string, object>>(
                    "MenuProducto",
                    r => r.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MenuProdu__IdPro__46E78A0C"),
                    l => l.HasOne<Menu>().WithMany()
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MenuProdu__IdMen__45F365D3"),
                    j =>
                    {
                        j.HasKey("IdMenu", "IdProducto").HasName("PK__MenuProd__5DE621C0AECF8F11");
                    });
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07643FF0AD");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__IdCate__3E52440B");
        });

        modelBuilder.Entity<Puntaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Puntaje__3214EC07492F9D64");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Puntaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Puntaje__IdProdu__412EB0B6");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC0711DB16BE");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sucursal__3214EC07FDE5CB12");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC0784CD9A1E");

            entity.Property(e => e.Password).IsFixedLength();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdRol__398D8EEE");

            entity.HasMany(d => d.IdSucursal).WithMany(p => p.IdUsuario)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioSucursal",
                    r => r.HasOne<Sucursal>().WithMany()
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioSu__IdSuc__4CA06362"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioSu__IdUsu__4BAC3F29"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdSucursal").HasName("PK__UsuarioS__D09ED34E3F61377D");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
