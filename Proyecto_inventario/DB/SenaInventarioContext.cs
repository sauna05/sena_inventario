using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_inventario.DB;

public partial class SenaInventarioContext : DbContext
{
    public SenaInventarioContext()
    {
    }

    public SenaInventarioContext(DbContextOptions<SenaInventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Elemento> Elementos { get; set; }

    public virtual DbSet<EstadoElemento> EstadoElementos { get; set; }

    public virtual DbSet<EstadoElementosPrestamo> EstadoElementosPrestamos { get; set; }

    public virtual DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }

    public virtual DbSet<FotoElemento> FotoElementos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DDD5B1P; Database=sena_inventario; trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("categorias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<Elemento>(entity =>
        {
            entity.ToTable("elementos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoElemento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_elemento");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.IdPersonaEncargada).HasColumnName("id_persona_encargada");
            entity.Property(e => e.NombreElemento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_elemento");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Elementos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_elementos_categorias");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Elementos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_elementos_estado_elementos");

            entity.HasOne(d => d.IdPersonaEncargadaNavigation).WithMany(p => p.Elementos)
                .HasForeignKey(d => d.IdPersonaEncargada)
                .HasConstraintName("FK_elementos_personas");
        });

        modelBuilder.Entity<EstadoElemento>(entity =>
        {
            entity.ToTable("estado_elementos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreEstadoElemento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_estado_elemento");
        });

        modelBuilder.Entity<EstadoElementosPrestamo>(entity =>
        {
            entity.ToTable("estado_elementos_prestamos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEstadoElemento).HasColumnName("id_estado_elemento");
            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");

            entity.HasOne(d => d.IdEstadoElementoNavigation).WithMany(p => p.EstadoElementosPrestamos)
                .HasForeignKey(d => d.IdEstadoElemento)
                .HasConstraintName("FK_estado_elementos_prestamos_estado_elementos");

            entity.HasOne(d => d.IdPrestamoNavigation).WithMany(p => p.EstadoElementosPrestamos)
                .HasForeignKey(d => d.IdPrestamo)
                .HasConstraintName("FK_estado_elementos_prestamos_prestamos");
        });

        modelBuilder.Entity<EstadoPrestamo>(entity =>
        {
            entity.ToTable("estado_prestamos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreEstadoPrestamo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_estado_prestamo");
        });

        modelBuilder.Entity<FotoElemento>(entity =>
        {
            entity.ToTable("foto_elementos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdElemento).HasColumnName("id_elemento");
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ruta_imagen");

            entity.HasOne(d => d.IdElementoNavigation).WithMany(p => p.FotoElementos)
                .HasForeignKey(d => d.IdElemento)
                .HasConstraintName("FK_foto_elementos_elementos");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("personas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numero_documento");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.ToTable("prestamos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaHoraPrestamo)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("fecha_hora_prestamo");
            entity.Property(e => e.FechaLimite).HasColumnName("fecha_limite");
            entity.Property(e => e.IdElemento).HasColumnName("id_elemento");
            entity.Property(e => e.IdEstadoPrestamo).HasColumnName("id_estado_prestamo");
            entity.Property(e => e.IdFuncionarioAutorizacion).HasColumnName("id_funcionario_autorizacion");
            entity.Property(e => e.IdPersonaPrestamo).HasColumnName("id_persona_prestamo");
            entity.Property(e => e.IdPortero).HasColumnName("id_portero");

            entity.HasOne(d => d.IdElementoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdElemento)
                .HasConstraintName("FK_prestamos_elementos");

            entity.HasOne(d => d.IdEstadoPrestamoNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdEstadoPrestamo)
                .HasConstraintName("FK_prestamos_estado_prestamos");

            entity.HasOne(d => d.IdFuncionarioAutorizacionNavigation).WithMany(p => p.PrestamoIdFuncionarioAutorizacionNavigations)
                .HasForeignKey(d => d.IdFuncionarioAutorizacion)
                .HasConstraintName("FK_prestamos_personas2");

            entity.HasOne(d => d.IdPersonaPrestamoNavigation).WithMany(p => p.PrestamoIdPersonaPrestamoNavigations)
                .HasForeignKey(d => d.IdPersonaPrestamo)
                .HasConstraintName("FK_prestamos_personas");

            entity.HasOne(d => d.IdPorteroNavigation).WithMany(p => p.PrestamoIdPorteroNavigations)
                .HasForeignKey(d => d.IdPortero)
                .HasConstraintName("FK_prestamos_personas1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IrRol).HasColumnName("ir_rol");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_usuarios_personas");

            entity.HasOne(d => d.IrRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IrRol)
                .HasConstraintName("FK_usuarios_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
