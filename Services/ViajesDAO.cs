using Microsoft.Data.SqlClient;
using ViajesColaboradores.Models;

namespace ViajesColaboradores.Services
{
    public class ViajesDAO : IDataViajesService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Registro;Integrated Security=False;
        Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
        ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(ViajeModel viaje)
        {
            throw new NotImplementedException();
        }

        public List<ViajeModel> GetAllViajes()
        {
            List<ViajeModel> viajesEncontrados = new List<ViajeModel>();

            string sqlStatement = "SELECT * FROM dbo.Table";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        viajesEncontrados.Add(new ViajeModel
                        {
                            Id = (int)reader[0],
                            Creado = (DateTime)reader[1],
                            Colaborador = (int)reader[2],
                            Sucursal = (int)reader[3],
                            Transportista = (int)reader[4],
                            Administrador = (int)reader[5],
                            Distancia = (int)reader[6],
                            ViajePosible = (bool)reader[7]
                        });
                    }

                } catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return viajesEncontrados;
        }

        public ViajeModel GetViajeById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ViajeModel viaje)
        {
            throw new NotImplementedException();
        }

        //Replaces get Viaje by id
       

        public List<ViajeModel> SearchViajes(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ViajeModel viaje)
        {
            throw new NotImplementedException();
        }
    }
}
