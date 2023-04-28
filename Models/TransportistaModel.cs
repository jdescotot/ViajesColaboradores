namespace ViajesColaboradores.Models
{
    public class TransportistaModel
    {
        public int Id { get; set; }
        public int Tarifa { get; set; }
        public string Nombre { get; set; }
        public bool LimiteViajes { get; set; }
    }
}
