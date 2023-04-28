namespace ViajesColaboradores.Models
{
    public class ColaboratorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public bool LimiteViajes { get; set; }
    }
}
