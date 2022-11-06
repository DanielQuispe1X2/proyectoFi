using Microsoft.AspNetCore.Mvc;

namespace proyectoFi.Controllers
{
    public class ClienteController : Controller
    {
        private readonly bdcarritoContext Context;


        public ClienteController(bdcarritoContext context)
        {

            Context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = Context.Clientes;
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
