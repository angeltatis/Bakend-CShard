using System.ComponentModel.DataAnnotations;

namespace MasterApiTatis.Application.DTOs
{
    public class MonedaDTO
    {
        public int Codmon { get; set; }

        [StringLength(45, MinimumLength = 1, ErrorMessage = "La descripción no puede ser menor a 1 ni mayor a 45")]
        [RegularExpression("^[^<>]*$", ErrorMessage = "La descripción contiene caracteres inválidos")]
        public string Desmon { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "La tasa no puede ser menor a 1")]
        public decimal Tasa { get; set; }

        public bool Estado { get; set; }

        // En lugar de incluir listas completas de Compras, Ordenes y Ventas, considera incluir solo información relevante.
        // Por ejemplo, podrías incluir el número de compras, ordenes y facturas asociadas a esta moneda, si es relevante.
        // Si necesitas detalles específicos de esas entidades, considera crear y usar DTOs separados para esas entidades.

        public int TotalCompras { get; set; }  // Ejemplo: número total de compras en esta moneda
        public int TotalOrdenes { get; set; }  // Ejemplo: número total de ordenes en esta moneda
        public int TotalFacturas { get; set; } // Ejemplo: número total de facturas en esta moneda
    }
}
