using ConsoleApp.Models;
using ConsoleApp.Repositories.Interfaces;
using ConsoleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class StarshipService : IStarshipService
    {
        private readonly IPilotRepository pilotRepository;
        private readonly IStarshipRepository starshipRepository;

        public StarshipService(IPilotRepository pilotRepository, IStarshipRepository starshipRepository)
        {
            this.pilotRepository = pilotRepository;
            this.starshipRepository = starshipRepository;
        }

        /// <summary>
        /// This service will get all starships with their existing pilots
        /// if it can hold a certain amount of passengers.
        /// </summary>
        /// <param name="passengerCount"></param>
        /// <returns></returns>
        public async Task<List<Starship>> GetStarshipsByPassengerCount(int passengerCount)
        {
            var starships = await starshipRepository.GetAll();
            var availableStarships = starships.Where(s =>
            {
                if (int.TryParse(s.Passengers, out var maxCapacity))
                {
                    if (maxCapacity >= passengerCount && s.PilotEndpoints != null)
                        return true;
                }
                return false;
            });

            var starshipViewList = new List<Starship>();

            foreach (var starship in availableStarships)
            {
                var starshipView = new Starship
                {
                    Name = starship.Name,
                    Pilots = new List<Pilot>()
                };

                if (starship.PilotEndpoints?.Count > 0)
                {
                    foreach (var endpoint in starship.PilotEndpoints)
                    {
                        var pilot = new Pilot
                        {
                            Id = Convert.ToInt32(endpoint.Split(@"/").Where(part => part != string.Empty).Last())
                        };

                        var pilotInfo = await pilotRepository.GetById(pilot.Id);
                        pilot.Name = pilotInfo.Name;
                        starshipView.Pilots.Add(pilot);
                    }
                }

                starshipViewList.Add(starshipView);
            }

            return starshipViewList;
        }
    }
}
