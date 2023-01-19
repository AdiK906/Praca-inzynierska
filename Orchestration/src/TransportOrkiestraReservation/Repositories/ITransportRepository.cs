using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportOrkiestraReservation.Models;

namespace TransportOrkiestraReservation.Repositories
{
    public interface ITransportRepository
    {
        public Task<TransportDto> AddTransportDto(TransportDto transportDto);
        public Task<List<TransportDto>> GetList();
        public Task<TransportDto> GetTransportById(Guid id);
        public Task<TransportDto> DeleteTransportDto(TransportDto transportDto);
    }
}
