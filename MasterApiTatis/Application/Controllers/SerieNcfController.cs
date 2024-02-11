using Microsoft.AspNetCore.Mvc;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;

namespace MasterApiTatis.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SerieNcfController : ControllerBase
    {
        private readonly ISerieNcfService _serieNcfService;

        public SerieNcfController(ISerieNcfService serieNcfService)
        {
            _serieNcfService = serieNcfService;
        }

        // GET: api/v1/SerieNcf
        [HttpGet]
        public async Task<IEnumerable<SerieNcf>> GetSeriess()
        {
            return await _serieNcfService.GetAllSeriesAsync();
        }

        // GET: api/SerieNcf/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SerieNcf>> GetSerie(string codserncf)
        {
            var serie = await _serieNcfService.GetSerieByIdAsync(codserncf);

            if (serie == null)
            {
                return NotFound();
            }

            return serie;
        }



    }
}
