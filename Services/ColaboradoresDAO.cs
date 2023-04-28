using Microsoft.Data.SqlClient;
using ViajesColaboradores.Models;

namespace ViajesColaboradores.Services
{
    public class ColaboradoresDAO : IDataColaboradorService
    {
        
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Registro;Integrated Security=False;
        Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
        ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(ColaboratorModel Colaborador)
        {
            throw new NotImplementedException();
        }

        public List<ColaboratorModel> GetAllColaboradores()
        {
            List<ColaboratorModel> colaboradoresEncontrados = new List<ColaboratorModel>();

            string sqlStatement = "SELECT * FROM dbo.Colaborator";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        colaboradoresEncontrados.Add(new ColaboratorModel
                        {
                            Id = (int)reader[0],
                            Nombre = (string)reader[1],
                            Apellido = (string)reader[2],
                            Direccion = (string)reader[3],
                            LimiteViajes = (bool)reader[4]
                        });
                    }

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return colaboradoresEncontrados;
        }

        public ColaboratorModel GetColaboradorById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ColaboratorModel Colaborador)
        {
            throw new NotImplementedException();
        }

        public List<ColaboratorModel> SearchColaboradores(string searchColaborador)
        {
            List<ColaboratorModel> ColaboradoresEncontrados = new List<ColaboratorModel>();
            string sqlStatement = "SELECT * FROM dbo.Colaborator WHERE Nombre LIKE @Nombre";
            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Nombre", '%' + searchColaborador + '%');
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ColaboradoresEncontrados.Add(new ColaboratorModel
                        {
                            Id = (int)reader[0],
                            Nombre = (string)reader[1],
                            Apellido = (string)reader[2],
                            Direccion = (string)reader[3],
                            LimiteViajes = (bool)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return ColaboradoresEncontrados;
        }

        public int Update(ColaboratorModel Colaborador)
        {
            throw new NotImplementedException();
        }
    }
}
