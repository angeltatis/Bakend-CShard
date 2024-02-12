using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Application.DTOs
{
    public class ClienteDTO
    {
        public int Codcli { get; set; }

        public string Numdoc { get; set; }

        public string Nom1 { get; set; }

        public string Nom2 { get; set; }

        public int Codcon { get; set; }

        public string Apepat { get; set; }

        public string Apemat { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool Estado { get; set; } = true;

        public List<VentaDTO> Ventas { get; set; }
    }

}
