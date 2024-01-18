﻿using MasterApiTatis.Interface;
using MasterApiTatis.Models;
using MasterApiTatis.Services;

namespace MasterApiTatis.Implemets
{
    public class UnidadImp : IUnidadService
    {
        private readonly IUnidadRepository _unidadRepository;

        public UnidadImp(IUnidadRepository unidadRepository)
        {
            _unidadRepository = unidadRepository;
        }

        public async Task AddUnidAsync(Unid unid)
        {
           await _unidadRepository.AddUnidAsync(unid);
        }

        public async Task desactivarUnidAsync(int id)
        {
            var unid = await _unidadRepository.GetUnidByIdAsync(id);

            if (unid == null)
            {
                throw new KeyNotFoundException("Unidad no existe");
            }

            unid.estado = !unid.estado;
            await _unidadRepository.UpdateUnidAsync(unid);
        }

        public async  Task<IEnumerable<Unid>> GetAllUnidsAsync()
        {
            return await _unidadRepository.GetAllUnidsAsync();
        }

        public async Task<Unid> GetUnidByIdAsync(int id)
        {
           return  await _unidadRepository.GetUnidByIdAsync(id);
        }

        public async Task<bool> UnidExistsAsync(int id)
        {
            return await _unidadRepository.UnidExistsAsync(id);
        }

        public async Task UpdateUnidAsync(int id, Unid unid)
        {
            if (id != unid.coduni)
                throw new ArgumentException("Id mismathc");
            // Check if the Unid exists in the repository
            bool exists = await _unidadRepository.UnidExistsAsync(unid.coduni);
            if (!exists)
            {
                throw new KeyNotFoundException("Unidad no existe.");
            }

            // If the Unid exists, update it
            await _unidadRepository.UpdateUnidAsync(unid);
        }
    }
}