using Microsoft.AspNetCore.Mvc;
using PrimeraPracticaNetCore.Data;
using PrimeraPracticaNetCore.Models;
using PrimeraPracticaNetCore.Repositories;

namespace PrimeraPracticaNetCore.Controllers
{
    public class ZapatillasController : Controller
    {
        private RepositoryZapatillas repo;

        public ZapatillasController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var zapatillas = await repo.GetZapatillasAsync();
            return View(zapatillas);
        }

        public async Task<IActionResult> Details
            (int? posicion, int idzapatilla)
        {
            if (posicion == null)
            {
                //POSICION PARA EL EMPLEADO
                posicion = 1;
            }
            DetallesZapatilla model = await
                this.repo.GetImagenesRegistros
                (posicion.Value, idzapatilla);

            ViewData["REGISTROS"] = model.NumeroRegistrosZapatillas;
            ViewData["ZAPATILLA"] = idzapatilla;
            int siguiente = posicion.Value + 1;
            //DEBEMOS COMPROBAR QUE NO PASAMOS DEL NUMERO DE REGISTROS
            if (siguiente > model.NumeroRegistrosZapatillas)
            {
                //EFECTO OPTICO
                siguiente = model.NumeroRegistrosZapatillas;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 1)
            {
                anterior = 1;
            }
            ViewData["ULTIMO"] = model.NumeroRegistrosZapatillas;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            ViewData["POSICION"] = posicion;
            return View(model.Zapatilla);
        }




    }



}
