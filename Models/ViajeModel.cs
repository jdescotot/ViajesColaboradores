using Microsoft.AspNetCore.Mvc.Rendering;

namespace ViajesColaboradores.Models
{
    public class ViajeModel
    {
        public int Id { get; set; }
        public DateTime Creado { get; set; }
        public int Colaborador { get; set; }
        public int Sucursal { get; set; }
        public int Transportista { get; set; }
        public int Administrador { get; set; }
        public int Distancia { get; set; }
        public bool ViajePosible { get; set; }
    }
}
