﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;

namespace MasterApiTatis.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductUnidsController : ControllerBase
    {
        private readonly IUnidProductService _productUnidService;

        public ProductUnidsController(IUnidProductService productUnidService)
        {
            _productUnidService = productUnidService;
        }

        // GET: api/v1/ProductUnids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unidad_producto>>> GetProductUnids()
        {
            return Ok(await _productUnidService.GetAllProductUnidsAsync());
        }

        // GET: api/v1/ProductUnids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unidad_producto>> GetProductUnid(int id)
        {
            var productUnid = await _productUnidService.GetProductUnidAsync(id);
            if (productUnid == null)
            {
                return NotFound();
            }
            return productUnid;
        }

        // PUT: api/v1/ProductUnids/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductUnid(int id, Unidad_producto productUnid)
        {
            if (id != productUnid.codunipro)
            {
                return BadRequest("El ID no coincide con el ID del objeto ProductUnid.");
            }

            try
            {
                await _productUnidService.UpdateProductUnidAsync(id, productUnid);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }

            return NoContent();
        }

        // POST: api/v1/ProductUnids
        // POST: api/v1/ProductUnids
        [HttpPost]
        public async Task<IActionResult> PostMultipleProductUnids([FromBody] List<Unidad_producto> productUnids)
        {
            if (productUnids == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var productUnid in productUnids)
            {
                await _productUnidService.CreateProductUnidAsync(productUnid);
            }

            return Ok(productUnids); // O podrías devolver otro tipo de respuesta si lo prefieres
        }


        // PUT: api/v1/ProductUnids/des/5
        [HttpPut("des/{id}")]
        public async Task<IActionResult> ToggleProductUnidStatus(int id)
        {
            try
            {
                await _productUnidService.ToggleProductUnidStatusAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, "No se pudo guardar los cambios. Error: " + ex.Message);
            }

            return NoContent();
        }
    }

}
