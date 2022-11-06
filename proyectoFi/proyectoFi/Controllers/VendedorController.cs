using Microsoft.AspNetCore.Mvc;

namespace proyectoFi.Controllers
{
    public class VendedorController : Controller
    {
        private readonly bdcarritoContext Context;

        public VendedorController(bdcarritoContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = Context.Vendedors;
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
        public IActionResult CreateVendedor(Vendedor obj)
        {
            if (ModelState.IsValid)
            {
                Context.Vendedors.Add(obj); //agregar datos al mysql
                Context.SaveChanges(); //graba los cambios
                return RedirectToAction("Index"); //si es correcto lo redirecciona al index 
            }
            else
            {
                return View("Create");  //si esta incorrecto lo regresa a la vista para ver los errores
            }
            
        }
        [Route("vendedor/Delete/{Codigo}")]
        public IActionResult Delete(int Codigo)
        {
            var Obj = (from Tave in Context.Vendedors
                       where Tave.CodVendedor == Codigo
                       select Tave).Single();
            Context.Vendedors.Remove(Obj);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("vendedor/Edit/{Codigo}")]
        public IActionResult Edit(int Codigo)
        {
            var Obj = (from Tave in Context.Vendedors
                       where Tave.CodVendedor == Codigo
                       select Tave).Single();
            ViewData["cod"] = Obj.CodVendedor;
            ViewData["nom"] = Obj.NomVendedor;
            ViewData["ape"] = Obj.ApeVendedor;
            ViewData["tele"] = Obj.TelVendedor;
            return View();
        }

        public IActionResult EditVendedor(Vendedor ObjNew)
        {
            if (ModelState.IsValid)
            {
                var ObjOld = (from Tave in Context.Vendedors
                              where Tave.CodVendedor == ObjNew.CodVendedor
                              select Tave).Single();
                ObjOld.NomVendedor = ObjNew.NomVendedor;
                ObjOld.ApeVendedor = ObjNew.ApeVendedor;
                ObjOld.TelVendedor = ObjNew.TelVendedor;

                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }
    }
}
