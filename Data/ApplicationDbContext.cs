using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ViajesColaboradores.Models;

namespace ViajesColaboradores.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ViajesColaboradores.Models.ViajeModel>? ViajeModel { get; set; }
        public DbSet<ViajesColaboradores.Models.ColaboratorModel>? ColaboratorModel { get; set; }
        public DbSet<ViajesColaboradores.Models.SucursalModel>? SucursalModel { get; set; }
        public DbSet<ViajesColaboradores.Models.TransportistaModel>? TransportistaModel { get; set; }
    }
}