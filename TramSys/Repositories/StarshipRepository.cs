using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp.Repositories.Interfaces;
using SwapiNet.Core.Models;
using SwapiNet.Core.Services;

namespace ConsoleApp.Repositories
{
    public class StarshipRepository: IStarshipRepository
    {
        /// <summary>
        /// Gets all starships
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Starship>> GetAll() => await ApiService.Instance.GetAll<Starship>();
    }
}
