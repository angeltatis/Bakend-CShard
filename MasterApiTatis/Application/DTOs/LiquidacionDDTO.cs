namespace MasterApiTatis.Application.DTOs
{
    public class LiquidacionDDTO
    {
        public int Coddliqui { get; set; }
        public string Desuni { get; set; }
        public decimal Fbo { get; set; }
        public decimal Monto { get; set; }
        public decimal Importe { get; set; }
        public decimal Coscif { get; set; }
        public decimal Cif { get; set; }
        public decimal Porgra { get; set; }
        public decimal Gravamen { get; set; }
        public decimal Porsele { get; set; }
        public decimal Selectivo { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Itebis { get; set; }
        public decimal Total { get; set; }
        public decimal Totalimp { get; set; }
        public decimal Cosdis { get; set; }
        public decimal Totalneto { get; set; }
        public int ProductoId { get; set; } // Solo el ID del producto
        public int SuplidorId { get; set; } // Solo el ID del suplidor
        public int LiquidacionId { get; set; } // Solo el ID de la liquidación
        public int MonedaId { get; set; } // Solo el ID de la moneda
    }
}
