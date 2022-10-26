using api.paises.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.paises.Controllers
{
    public class PaisesController : Controller
    {
        // GET: PaisesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaisesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaisesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisesController/Create
        [HttpPost("paises/create")]
        public ActionResult Create([FromBody] Models.paises _paises)
        {
            try
            {
                conexionPostgres _conexionPostgres = new conexionPostgres();
                _conexionPostgres.CrearPais(_paises);
                return Ok("Se insertó correctamente el pais " + _paises.pais);
            }
            catch(Exception ex)
            {
                return StatusCode(400, "Error en la api: " + ex.Message);
            }
        }

        // GET: PaisesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaisesController/Edit/5
        [HttpPost("paises/edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaisesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
