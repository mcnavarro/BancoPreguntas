// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220618231159_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Core.Entities.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EscuelaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EscuelaId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Core.Entities.Escuela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InstitucionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstitucionId");

                    b.ToTable("Escuelas");
                });

            modelBuilder.Entity("Core.Entities.Evaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HabilitadoModificacion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumeralId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoEvaluacionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("NumeralId");

                    b.HasIndex("TipoEvaluacionId");

                    b.ToTable("Evaluaciones");
                });

            modelBuilder.Entity("Core.Entities.Institucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Instituciones");
                });

            modelBuilder.Entity("Core.Entities.Numeral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Numerales");
                });

            modelBuilder.Entity("Core.Entities.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("TEXT");

                    b.Property<int>("EvaluacionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EvaluacionId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("Core.Entities.Respuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EsCorrecta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("Core.Entities.TipoEvaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TiposEvaluacion");
                });

            modelBuilder.Entity("Core.Entities.Curso", b =>
                {
                    b.HasOne("Core.Entities.Escuela", "Escuela")
                        .WithMany()
                        .HasForeignKey("EscuelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escuela");
                });

            modelBuilder.Entity("Core.Entities.Escuela", b =>
                {
                    b.HasOne("Core.Entities.Institucion", "Institucion")
                        .WithMany()
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucion");
                });

            modelBuilder.Entity("Core.Entities.Evaluacion", b =>
                {
                    b.HasOne("Core.Entities.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Numeral", "Numeral")
                        .WithMany()
                        .HasForeignKey("NumeralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoEvaluacion", "TipoEvaluacion")
                        .WithMany()
                        .HasForeignKey("TipoEvaluacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Numeral");

                    b.Navigation("TipoEvaluacion");
                });

            modelBuilder.Entity("Core.Entities.Pregunta", b =>
                {
                    b.HasOne("Core.Entities.Evaluacion", "Evaluacion")
                        .WithMany()
                        .HasForeignKey("EvaluacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("Core.Entities.Respuesta", b =>
                {
                    b.HasOne("Core.Entities.Pregunta", "Pregunta")
                        .WithMany()
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pregunta");
                });
#pragma warning restore 612, 618
        }
    }
}
