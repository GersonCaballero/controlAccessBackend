using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlAccess.Models;

namespace ControlAccess.Data
{
    public class ControlAccessContext : DbContext
    {
        public ControlAccessContext (DbContextOptions<ControlAccessContext> options)
            : base(options)
        {
        }

        public DbSet<ControlAccess.Models.Residencial> Residencial { get; set; } = default!;
        public DbSet<ControlAccess.Models.Zonas> Zonas { get; set; } = default!;
        public DbSet<ControlAccess.Models.Casas> Casas { get; set; } = default!;
        public DbSet<ControlAccess.Models.Calles> Calles { get; set; } = default!;
        public DbSet<ControlAccess.Models.Avenidas> Avenidas { get; set; } = default!;
        public DbSet<ControlAccess.Models.Bloque> Bloque { get; set; } = default!;
        public DbSet<ControlAccess.Models.Inmuebles> Inmuebles { get; set; } = default!;
        public DbSet<ControlAccess.Models.TipoUsuario> TipoUsuario { get; set; } = default!;
        public DbSet<ControlAccess.Models.Usuarios> Usuarios { get; set; } = default!;
        public DbSet<ControlAccess.Models.Tarifas> Tarifas { get; set; } = default!;
        public DbSet<ControlAccess.Models.Visitantes> Visitantes { get; set; } = default!;
        public DbSet<ControlAccess.Models.Vehiculos> Vehiculos { get; set; } = default!;
        public DbSet<ControlAccess.Models.Reportes> Reportes { get; set; } = default!;
        public DbSet<ControlAccess.Models.Incidencias> Incidencias { get; set; } = default!;
        public DbSet<ControlAccess.Models.Accesos> Accesos { get; set; } = default!;
    }
}
