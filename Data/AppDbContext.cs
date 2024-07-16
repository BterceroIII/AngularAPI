using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(tb =>
            {
                tb.HasKey(col => col.IdDepartamento);

                tb.Property(col => col.IdDepartamento)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre)
                .HasMaxLength(20);
            });
            modelBuilder.Entity<Departamento>().ToTable("Departamento");

            modelBuilder.Entity<Empleado>(tb =>
            {
                tb.HasKey(col => col.IdEmpleado);

                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.Nombre)
                .HasMaxLength(20);
                tb.Property(col => col.Apellido)
                .HasMaxLength(20);
                tb.Property(col => col.Sueldo)
                .HasColumnType("decimal(18,2)");


                //definicion de llave primaria
                tb.Property(col => col.IdDepartamento).IsRequired();

                tb.HasOne(e => e.Departamento)
                .WithMany(d => d.Empleados)
                .HasForeignKey(e => e.IdDepartamento)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
        }
    }
}
