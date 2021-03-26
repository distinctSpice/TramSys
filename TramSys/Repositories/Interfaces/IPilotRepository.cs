using SwapiNet.Core.Models;
using System.Threading.Tasks;

namespace ConsoleApp.Repositories.Interfaces
{
    public interface IPilotRepository
    {
        public Task<Person> GetById(int id);
    }
}
