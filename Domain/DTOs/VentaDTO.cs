namespace MasterApiTatis.Application.DTOs
{
    public class VentaDTO
    {
        public int Codven { get; set; }
        public int ClienteId { get; set; }
        public int MonedaId { get; set; }
        public int CondicionId { get; set; }
        public int TipoNcfId { get; set; }
        public string Ncf { get; set; }
        public DateTime Fectra { get; set; }
        public DateTime Fecven { get; set; }
        public decimal Desven { get; set; }
        public decimal Itbistotal { get; set; }
        public decimal Otro { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }

        // Si necesitas incluir detalles de las ventas, deberías usar un DTO para los detalles también
        public List<VentaDDTO> DetallesVentasDTO { get; set; }
    }
}
