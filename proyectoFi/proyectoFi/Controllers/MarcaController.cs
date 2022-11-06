using Microsoft.AspNetCore.Mvc;

namespace proyectoFi.Controllers
{
    public class MarcaController : Controller
    {
        private readonly bdcarritoContext Context;
        public MarcaController(bdcarritoContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = Context.Marcas;

            return View(list);
        }

        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
