
namespace MasterApiTatis.Application.DTOs
{
    public class SolicitudNcfDDTO
    {
        public int Codcli { get; set; }
        public string Numdoc { get; set; }
        public string Nom1 { get; set; }
        public string Nom2 { get; set; }
        public int CondicionId { get; set; } // Solo necesitas el ID de la condición
        public string Apepat { get; set; }
        public string Apemat { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Estado { get; set; }

        // Considera incluir detalles resumidos o contadores en lugar de la lista completa de entidades relacionadas
        // Por ejemplo, si solo necesitas saber la cantidad de ventas asociadas, puedes usar un contador
        public int TotalVentas { get; set; }
    }
}
