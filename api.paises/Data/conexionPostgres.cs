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
                descripcion = _paises.descripcion,
                estado = _paises.estado,
            };

            conexion.ExecuteScalar(sql, arguments);

            return "";
        }

        public IEnumerable<Models.paises> GetPaises()
        {
            string SQL = "select * from paises";
            conexion.Open();
            var paises = conexion.Query<Models.paises>(SQL);

            return paises;
        }

        public Models.paises GetPais(int id)
        {
            string SQL = "select * from paises where id = " + id;
            conexion.Open();
            var pais = conexion.QueryFirst<Models.paises>(SQL);

            return pais;
        }

        public bool ModificarPais(Models.paises _paises, int _id)
        {
            try
            {
                this.conexion.Open();

                string sql = "UPDATE paises SET " +
                    " id = @id, " +
                    " descripcion = @descripcion, " +
                    " estado = @estado " +
                    " WHERE id = " + _id;

                var arguments = new
                {
                    id = _paises.id,
                    descripcion = _paises.descripcion,
                    estado = _paises.estado,
                };

                conexion.Execute(sql, arguments);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarPais(int id)
        {
            try
            {
                string SQL = "DELETE FROM paises WHERE id = " + id;
                conexion.Execute(SQL);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
