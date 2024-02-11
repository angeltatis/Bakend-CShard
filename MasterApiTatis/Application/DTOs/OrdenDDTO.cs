namespace MasterApiTatis.Application.DTOs
{
    public class OrdenDDTO
    {
        public int Numdord { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Itebis { get; set; }
        public decimal Importe { get; set; }
        public bool Estado { get; set; }
        public int ProductoId { get; set; } // Solo necesitas el ID del producto
        public int OrdenId { get; set; } // Solo necesitas el ID de la orden
    }
}
