using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL_New;

public partial class UsuarioPruebaContext : DbContext
{
    public UsuarioPruebaContext()
    {
    }

    public UsuarioPruebaContext(DbContextOptions<UsuarioPruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    // ⚠️ DTOs (para SP o vistas)
    public virtual DbSet<UsuarioDTO> GetAll { get; set; }
    public virtual DbSet<UsuarioDTO> GetById { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 🔥 SOLUCIÓN ERROR DTO (SIN PK)
        modelBuilder.Entity<UsuarioDTO>().HasNoKey();

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol)
                  .HasName("PK__Roles__2A49584CA6E8C590");

            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario)
                  .HasName("PK__Usuario__5B65BF978CA6C2DC");

            entity.ToTable("Usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .IsUnicode(false);

            entity.Property(e => e.Estatus)
                .HasDefaultValue(true);

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            // 🔥 IMPORTANTE: BCrypt necesita más espacio
            entity.Property(e => e.Password)
                .HasMaxLength(255) // ✅ ANTES: 10 (ERROR)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}