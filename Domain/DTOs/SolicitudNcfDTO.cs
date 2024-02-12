namespace MasterApiTatis.Application.DTOs
{
    public class SolicitudNcfDTO
    {
        public string Codsol { get; set; }
        public DateTime Fecsol { get; set; }
        public DateTime Fecven { get; set; }
        public int SerieId { get; set; } // Solo necesitas el ID de la serie
        public bool Estado { get; set; }

        // Si necesitas incluir detalles de las solicitudes NCF, considera usar un DTO para los detalles también
        public List<SolicitudNcfDDTO> DetallesNcfDTO { get; set; }
    }
}
