using Microsoft.EntityFrameworkCore;

namespace PrimeraPracticaNetCore.Models
{
    public class DetallesZapatilla
    {
        public int NumeroRegistrosZapatillas { get; set; }
        public Zapatilla Zapatilla { get; set; }

        public List<Imagen> Imagenes { get; set; }
    }


}
