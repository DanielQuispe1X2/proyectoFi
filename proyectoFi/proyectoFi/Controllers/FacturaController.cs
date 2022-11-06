using Microsoft.AspNetCore.Mvc;

namespace proyectoFi.Controllers
{
    public class FacturaController : Controller
    {
        private readonly bdcarritoContext Context;

        public FacturaController(bdcarritoContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = Context.Facturas;
            return View(list);
        }

        public IActionResult Listar()
        {
            return View();
        }
    }
}
