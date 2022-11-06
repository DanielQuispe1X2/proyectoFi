using Microsoft.AspNetCore.Mvc;

namespace proyectoFi.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly bdcarritoContext Context;
        public CategoriaController(bdcarritoContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = Context.Categoria;
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
