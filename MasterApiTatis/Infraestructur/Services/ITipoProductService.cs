﻿using MasterApiTatis.Domain.Models;

namespace MasterApiTatis.Infraestructur.Services
{
    public interface ITipoProductService
    {

        Task<IEnumerable<TipoProduct>> GetAllTipoProductsAsync();
        Task<TipoProduct> GetTipoProductAsync(int id);
        Task UpdateTipoProductAsync(int id, TipoProduct tipoProduct);
        Task CreateTipoProductAsync(TipoProduct tipoProduct);
        Task<bool> TipoExist(int id);
        Task ToggleTipoProductStatusAsync(int id);
    }
}
