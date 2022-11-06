using Microsoft.AspNetCore.Mvc;

namespace proyectoFi.Controllers
{
    public class ProductoController : Controller
    {
        private readonly bdcarritoContext Context;
        public ProductoController(bdcarritoContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = Context.Productos;
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
