using AtractionsOrkiestraReservation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtractionsOrkiestraReservation.Repositories
{
    public interface IAtractionsRepository
    {
        public Task<AtractionDto> AddAtractionDto(AtractionDto atractionDto);
        public Task<List<AtractionDto>> GetList();
        public AtractionDto DeleteAtractionDto(AtractionDto atractionDto);
    }
}
