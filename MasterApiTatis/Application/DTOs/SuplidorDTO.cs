namespace MasterApiTatis.Application.DTOs
{
    public class SuplidorDTO
    {
        public int Codsup { get; set; }
        public string Rnc { get; set; }
        public string Nomsup { get; set; }
        public string Desdir { get; set; }
        public string Telefono { get; set; }
        public string Codtipncf { get; set; }
        public int Codcon { get; set; }
        public bool Estado { get; set; }

        // Considera incluir contadores o listas de DTOs para las relaciones en lugar de las entidades completas
        public int TotalOrdenes { get; set; } // Ejemplo: número total de órdenes asociadas a este suplidor
        public int TotalLiquidaciones { get; set; } // Ejemplo: número total de liquidaciones asociadas a este suplidor
        public int TotalCompras { get; set; } // Ejemplo: número total de compras asociadas a este suplidor
    }

}
