namespace MasterApiTatis.Application.DTOs
{
    public class LiquidacionDTO
    {
        public int CodiLiq { get; set; }
        public int Codbl { get; set; }
        public DateTime FeciLiq { get; set; }
        public decimal Importe { get; set; }
        public decimal Tasadu { get; set; }
        public decimal Coscifrd { get; set; }
        public decimal Cosfact { get; set; }
        public decimal Otrcos { get; set; }
        public string Nota { get; set; }
        public int MonedaId { get; set; } // Solo necesitas el ID de la moneda

        // Si necesitas incluir detalles de las liquidaciones, considera usar un DTO para los detalles también
        public List<LiquidacionDDTO> DetallesDTO { get; set; }
    }
}
