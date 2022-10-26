using api.paises.Models;
using Dapper;

namespace api.paises.Data
{
    public class conexionPostgres
    {
        #region Variables
        private string CadenaConexion = "Server=localhost;Port=5432;Database=OpticaPortal;User Id=postgres;Password=changeme;";

        private Npgsql.NpgsqlConnection conexion;
        
        #endregion

        #region Constructor
        public conexionPostgres()
        {
            this.conexion = new Npgsql.NpgsqlConnection(CadenaConexion);
        }
        #endregion

        #region Lista de métodos
        public string CrearPais(Models.paises _paises)
        {
            this.conexion.Open();
            
            string sql = "INSERT INTO paises(id, descripcion, estado) VALUES (@id, @descripcion, @estado)";

            var arguments = new
            {
                id = _paises.id,
                descripcion = _paises.pais,
                estado = _paises.estado,
            };

            conexion.ExecuteScalar(sql, arguments);

            return "";
        }
        #endregion
    }
}
