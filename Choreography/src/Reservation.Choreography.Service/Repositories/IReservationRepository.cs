using Reservation.Choreography.Service.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Choreography.Service.Repositories
{
    public interface IReservationRepository
    {
        public Task<ReservationDto> AddReservationDto(ReservationDto reservationDto);
        public Task<List<ReservationDto>> GetList();
        public ReservationDto DeleteReservationDto(ReservationDto reservationDto);
    }
}
