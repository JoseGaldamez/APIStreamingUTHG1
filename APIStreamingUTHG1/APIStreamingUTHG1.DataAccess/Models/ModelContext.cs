using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIStreamingUTHG1.DataAccess.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Regione> Regiones { get; set; }

    public virtual DbSet<Suscripcione> Suscripciones { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ValoracionesYComentario> ValoracionesYComentarios { get; set; }

    public virtual DbSet<Contenido> Contenidos { get; set; }

    public virtual DbSet<Resumen> Resumens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
// optionsBuilder.UseOracle("User Id=UTH20230201;Password=UTH20230201;Data Source=173.249.59.89:1521/ORCLCDB;");
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("UTH20230201")
            .UseCollation("USING_NLS_COMP");


        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("SYS_C0010372");

            entity.ToTable("PLANES");

            entity.Property(e => e.IdPlan)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_PLAN");
            entity.Property(e => e.CostoMensual)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("COSTO_MENSUAL");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.NombrePlan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PLAN");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("UPDATED_AT");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("UPDATED_BY");
        });

        

        modelBuilder.Entity<Regione>(entity =>
        {
            entity.HasKey(e => e.IdRegion).HasName("SYS_C0010361");

            entity.ToTable("REGIONES");

            entity.Property(e => e.IdRegion)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_REGION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDIOMA");
            entity.Property(e => e.NombreRegion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_REGION");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PAIS");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("UPDATED_AT");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("CREATED_BY");
        });


        modelBuilder.Entity<Suscripcione>(entity =>
        {
            entity.HasKey(e => e.IdSuscipcion).HasName("SYS_C0010379");

            entity.ToTable("SUSCRIPCIONES");

            entity.Property(e => e.IdSuscipcion)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_SUSCRIPCION");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ESTADO_PAGO");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_INICIO");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_VENCIMIENTO");
            entity.Property(e => e.IdPlan)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_PLAN");
            entity.Property(e => e.IdUsuario)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UPDATED_AT");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UPDATED_BY");
        });

        

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("SYS_C0010342");

            entity.ToTable("USERS");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UPDATED_AT");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UPDATED_BY");
        });


        modelBuilder.Entity<ValoracionesYComentario>(entity =>
        {
            entity.HasKey(e => e.IdValoracionc).HasName("SYS_C0010638");

            entity.ToTable("VALORACIONES_Y_COMENTARIOSS");

            entity.Property(e => e.IdValoracionc)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_VALORACIONC");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_USUARIO");

            entity.Property(e => e.IdContenido)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CONTENIDO");

            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("COMENTARIO");

            entity.Property(e => e.FechaComentario)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_COMENTARIO");

            entity.Property(e => e.Valoracion)
                .HasColumnType("NUMBER(2,1)")
                .HasColumnName("VALORACION");

            entity.Property(e => e.CreatedAt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_AT");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UPDATED_AT");

            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UPDATED_BY");

        });

        modelBuilder.Entity<Contenido>(entity =>
        {
            entity.HasKey(e => e.IdContenido).HasName("SYS_C0010372");

            entity.ToTable("CONTENIDOS");

            entity.Property(e => e.IdContenido)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CONTENIDO");
            entity.Property(e => e.TipoContenido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIPO_CONTENIDO");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TITULO");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GENERO");
            entity.Property(e => e.YearLanzamiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("YEAR_LANZAMIENTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECTOR");
            entity.Property(e => e.Duracion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DURACION");
            entity.Property(e => e.Calificaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CALIFICACIONES");
            entity.Property(e => e.Clasificaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLASIFICACION");
            entity.Property(e => e.IdRegion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_REGION");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("UPDATED_AT");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false).IsRequired(false)
                .HasColumnName("UPDATED_BY");
        });



        modelBuilder.Entity<Resumen>(entity =>
        {
            entity.HasKey(e => e.IdResumen).HasName("SYS_C0010615");

            entity.ToTable("RESUMEN");

            entity.Property(e => e.IdResumen)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_RESUMEN");

            entity.Property(e => e.IdContenido)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CONTENIDO");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_USUARIO");

            entity.Property(e => e.IdSuscripcion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_SUSCRIPCION");

            entity.Property(e => e.IdPlan)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_PLAN");

            entity.Property(e => e.IdValoracion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_VALORACIONC");

            entity.Property(e => e.IdRegion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_REGION");

            entity.Property(e => e.IdHistorial)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_HISTORIAL");

        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
