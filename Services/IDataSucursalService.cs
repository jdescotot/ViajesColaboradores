using ViajesColaboradores.Models;

namespace ViajesColaboradores.Services
{
    public interface IDataSucursalService
    {
        List<SucursalModel> GetAllSucursales();
        List<SucursalModel> SearchSucursales(string searchTerm);
        SucursalModel GetSucursalById(int id);
        int Insert(SucursalModel sucursal);
        int Delete(SucursalModel sucursal);
        int Update(SucursalModel sucursal);
    }
}
