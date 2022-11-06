using Microsoft.AspNetCore.Mvc;

namespace proyectoFi.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private readonly bdcarritoContext Context;
        public DetalleFacturaController(bdcarritoContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = Context.DetalleFacturas;
            return View(list);
        }
        public IActionResult Listar()
        {
            return View();
        }
    }
}
