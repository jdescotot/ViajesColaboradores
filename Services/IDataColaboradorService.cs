using ViajesColaboradores.Models;

namespace ViajesColaboradores.Services
{
    public interface IDataColaboradorService
    {
        List<ColaboratorModel> GetAllColaboradores();
        List<ColaboratorModel> SearchColaboradores(string searchTerm);
        ColaboratorModel GetColaboradorById(int id);
        int Insert(ColaboratorModel Colaborador);
        int Delete(ColaboratorModel Colaborador);
        int Update(ColaboratorModel Colaborador);
    }
}
