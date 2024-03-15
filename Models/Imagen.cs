using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrimeraPracticaNetCore.Models
{
    [Table("IMAGENESZAPASPRACTICA")]
    public class Imagen
    {
        [Key]
        [Column("IDIMAGEN")]
        public int IdImagen { get; set; }

        [Column("IDPRODUCTO")]
        public int IdProducto { get; set; }

        [Column("IMAGEN")]
        public string Link { get; set; }

        [ForeignKey("IdProducto")]
        public Zapatilla Zapatilla { get; set; }
    }
}
