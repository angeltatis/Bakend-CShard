namespace MasterApiTatis.Application.DTOs
{
    public class OrdenDTO
    {
        public int Codord { get; set; }
        public int MonedaId { get; set; } // Solo necesitas el ID de la moneda
        public int CondicionId { get; set; } // Solo necesitas el ID de la condición
        public DateTime Fecpro { get; set; }
        public DateTime Fecfin { get; set; }
        public decimal Itebis { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }
        public int SuplidorId { get; set; } // Solo necesitas el ID del suplidor

        // Si necesitas incluir detalles de las órdenes, considera usar un DTO para los detalles también
        public List<OrdenDDTO> DetallesDTO { get; set; }
    }
}
