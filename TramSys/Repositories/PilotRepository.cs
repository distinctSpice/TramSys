using ConsoleApp.Repositories.Interfaces;
using SwapiNet.Core.Models;
using SwapiNet.Core.Services;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories
{
    public class PilotRepository : IPilotRepository
    {
        /// <summary>
        /// Gets a Star Wars person by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> GetById(int id) => await ApiService.Instance.GetById<Person>(id);
    }
}
