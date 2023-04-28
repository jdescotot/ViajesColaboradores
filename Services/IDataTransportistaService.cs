using ViajesColaboradores.Models;

namespace ViajesColaboradores.Services
{
    public interface IDataTransportistaService
    {
        List<TransportistaModel> GetAllTransportistas();
        List<TransportistaModel> SearchTransportistas(string searchTerm);
        TransportistaModel GetTransportistaById(int id);
        int Insert(TransportistaModel transportista);
        int Delete(TransportistaModel transportista);
        int Update(TransportistaModel transportista);
    }
}
