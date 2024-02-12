namespace MasterApiTatis.Application.DTOs
{
    public class SerieNcfDTO
    {
        public string Codser { get; set; }
        public bool Estado { get; set; } = true;

        // Considera incluir detalles resumidos o contadores en lugar de la lista completa de entidades relacionadas
        // Por ejemplo, si solo necesitas saber la cantidad de SolicitudNcfD asociadas, puedes usar un contador
        public int TotalSolicitudes { get; set; }

    }
}
