using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrimeraPracticaNetCore.Data;
using PrimeraPracticaNetCore.Models;
using System.Data;


#region

/*
 * 

ALTER PROCEDURE SP_IMAGENES_ZAPAS_OUT
    @posicion INT,
    @idzapatilla INT,
    @registros INT OUTPUT
AS
BEGIN
    SELECT @registros = COUNT(IMAGEN) 
    FROM IMAGENESZAPASPRACTICA
    WHERE IDPRODUCTO = @idzapatilla;

    SELECT IDIMAGEN, IDPRODUCTO, IMAGEN
    FROM (
        SELECT CAST(ROW_NUMBER() OVER (ORDER BY IMAGEN) AS INT) AS POSICION,
               IDIMAGEN,
               IDPRODUCTO,
               IMAGEN
        FROM IMAGENESZAPASPRACTICA
        WHERE IDPRODUCTO = @idzapatilla
    ) AS QUERY
    WHERE QUERY.POSICION = @posicion;
END



*/

#endregion


namespace PrimeraPracticaNetCore.Repositories
{
    public class RepositoryZapatillas
    {

        private ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }


        public async Task<List<Zapatilla>> GetZapatillasAsync()
        {
            return await this.context.Zapatillas.ToListAsync();
        }

        public async Task<DetallesZapatilla>
           GetImagenesRegistros
           (int posicion, int idzapa)
        {
            string sql = "SP_IMAGENES_ZAPAS_OUT @posicion, @idzapatilla, "
                + " @registros out";
            SqlParameter pamPosicion = new SqlParameter("@posicion", posicion);
            SqlParameter pamZapatilla =
                new SqlParameter("@idzapatilla", idzapa);
            SqlParameter pamRegistros = new SqlParameter("@registros", -1);
            pamRegistros.Direction = ParameterDirection.Output;
            var consulta =
                this.context.Zapatillas.FromSqlRaw
                (sql, pamPosicion, pamZapatilla, pamRegistros);
            //PRIMERO DEBEMOS EJECUTAR LA CONSULTA PARA PODER RECUPERAR 
            //LOS PARAMETROS DE SALIDA
            var datos = await consulta.ToListAsync();
            Zapatilla zapa = datos.FirstOrDefault();
            int registros = (int)pamRegistros.Value;
            return new DetallesZapatilla
            {
                NumeroRegistrosZapatillas = registros,
                Zapatilla = zapa
            };
        }






    }
}
