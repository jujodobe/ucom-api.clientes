using api.paises.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.paises.Controllers
{
    public class PaisesController : Controller
    {
        // GET: PaisesController
        [HttpGet("paises/consultarPaises")]
        public ActionResult Index()
        {
            conexionPostgres _conexionPostgres = new conexionPostgres();
            var paises = _conexionPostgres.GetPaises();
            return Ok(paises);
        }

        // GET: PaisesController/Details/5
        [HttpGet("paises/consultarPais")]
        public ActionResult Details(int id)
        {
            conexionPostgres _conexionPostgres = new conexionPostgres();
            var pais = _conexionPostgres.GetPais(id);
            return Ok(pais);
        }

        // POST: PaisesController/Create
        [HttpPost("paises/create")]
        public ActionResult Create([FromBody] Models.paises _paises)
        {
            try
            {
                conexionPostgres _conexionPostgres = new conexionPostgres();
                _conexionPostgres.CrearPais(_paises);
                return Ok("Se insertó correctamente el pais " + _paises.descripcion);
            }
            catch(Exception ex)
            {
                return StatusCode(400, "Error en la api: " + ex.Message);
            }
        }

        // POST: PaisesController/Edit/5
        [HttpPut("paises/edit")]
        public ActionResult Edit([FromBody]Models.paises pais, int id)
        {
            try
            {
                conexionPostgres _conexionPostgres = new conexionPostgres();
                _conexionPostgres.ModificarPais(pais, id);
                return Ok("el país fue modificado con éxito");
            }
            catch
            {
                return View();
            }
        }


        // POST: PaisesController/Delete/5
        [HttpDelete("paises/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                conexionPostgres _conexionPostgres = new conexionPostgres();
                _conexionPostgres.EliminarPais(id);
                return Ok("El registro se eliminó correctamente");
            }
            catch
            {
                return View();
            }
        }
    }
}
