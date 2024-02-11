namespace MasterApiTatis.Application.DTOs
{
    public class CompraDTO
    {
        public int Codcom { get; set; }
        public int SuplidorId { get; set; }
        public int CondicionId { get; set; }
        public int MonedaId { get; set; }
        public string Ncf { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal ItebiTotal { get; set; }
        public decimal DesTotal { get; set; }
        public decimal MontoTotal { get; set; }
        public bool Estado { get; set; }

        // Si necesitas incluir detalles de las compras, deberías usar un DTO para los detalles también
        public List<CompraDDTO> CompraDetalleDTO { get; set; }
    }
}
