using ViajesColaboradores.Models;

namespace ViajesColaboradores.Services
{
    public interface IDataViajesService
    {
        List<ViajeModel> GetAllViajes();
        List<ViajeModel> SearchViajes(string searchTerm);
        ViajeModel GetViajeById(int id);
        int Insert(ViajeModel viaje);
        int Delete(ViajeModel viaje);
        int Update(ViajeModel viaje);
    }
}
