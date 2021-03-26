using SwapiNet.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories.Interfaces
{
    public interface IStarshipRepository
    {
        public Task<IEnumerable<Starship>> GetAll();
    }
}
