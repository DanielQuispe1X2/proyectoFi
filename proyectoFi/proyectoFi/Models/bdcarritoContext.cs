using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyectoFi.Models
{
    public partial class bdcarritoContext : DbContext
    {
        public bdcarritoContext()
        {
        }

        public bdcarritoContext(DbContextOptions<bdcarritoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=bdcarrito;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.NomCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categoria");

                entity.Property(e => e.NomCategoria)
                    .HasMaxLength(80)
                    .HasColumnName("nomCategoria");

                entity.Property(e => e.IdCategoria)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCategoria");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.CodCliente)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("codCliente");

                entity.Property(e => e.ApeCliente)
                    .HasMaxLength(80)
                    .HasColumnName("apeCliente");

                entity.Property(e => e.DireCliente)
                    .HasMaxLength(200)
                    .HasColumnName("direCliente");

                entity.Property(e => e.DniCliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("dniCliente");

                entity.Property(e => e.NomCliente)
                    .HasMaxLength(60)
                    .HasColumnName("nomCliente");

                entity.Property(e => e.telefono)
                    .HasColumnType("int(11)")
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("detalle_factura");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.CodFactura)
                    .HasColumnType("int(11)")
                    .HasColumnName("codFactura");

                entity.Property(e => e.CodProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("codProducto");

                entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.CodFactura)
                    .HasName("PRIMARY");

                entity.ToTable("factura");

                entity.HasIndex(e => e.CodCliente, "codCliente");

                entity.Property(e => e.CodFactura)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("codFactura");

                entity.Property(e => e.CodCliente)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("codCliente");

                entity.Property(e => e.Estado)
                    .HasMaxLength(20)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(10)
                    .HasColumnName("fecha");

                entity.Property(e => e.IgvFactura).HasColumnName("igvFactura");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.TipoVenta)
                    .HasMaxLength(30)
                    .HasColumnName("tipoVenta");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_ibfk_1");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.NomMarca)
                    .HasName("PRIMARY");

                entity.ToTable("marca");

                entity.Property(e => e.NomMarca)
                    .HasMaxLength(80)
                    .HasColumnName("nomMarca");

                entity.Property(e => e.IdMarca)
                    .HasColumnType("int(11)")
                    .HasColumnName("idMarca");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.NomMarca, "nomMarca");

                entity.Property(e => e.CodProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("codProducto");

                entity.Property(e => e.NomMarca)
                    .HasMaxLength(80)
                    .HasColumnName("nomMarca");

                entity.Property(e => e.NomProducto)
                    .HasMaxLength(100)
                    .HasColumnName("nomProducto");

                entity.Property(e => e.PrecioProducto).HasColumnName("precioProducto");

                entity.Property(e => e.TipoProducto)
                    .HasMaxLength(80)
                    .HasColumnName("tipoProducto");

                entity.HasOne(d => d.NomMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.NomMarca)
                    .HasConstraintName("producto_ibfk_1");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.CodVendedor)
                    .HasName("PRIMARY");

                entity.ToTable("vendedor");

                entity.Property(e => e.CodVendedor)
                    .HasColumnType("int(11)")
                    .HasColumnName("codVendedor");

                entity.Property(e => e.ApeVendedor)
                    .HasMaxLength(80)
                    .HasColumnName("apeVendedor");

                entity.Property(e => e.NomVendedor)
                    .HasMaxLength(80)
                    .HasColumnName("nomVendedor");

                entity.Property(e => e.TelVendedor)
                    .HasColumnType("int(11)")
                    .HasColumnName("telVendedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
