using ConsoleApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp.Services.Interfaces
{
    public interface IStarshipService
    {
        public Task<List<Starship>> GetStarshipsByPassengerCount(int passengerCount);
    }
}
