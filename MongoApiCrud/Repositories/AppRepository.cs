using Microsoft.EntityFrameworkCore;
using MongoApiCrud.DataContext;
using MongoApiCrud.Models;
using MongoDB.Bson;

namespace MongoApiCrud.Repositories
{
    public class AppRepository
    {
        public AppDbContext _context;
        public ILogger<AppRepository> _logger;
        public AppRepository(AppDbContext appDbContext,ILogger<AppRepository> logger) 
        { 
            _context = appDbContext;
            _logger = logger;
        }

        public async Task<List<Planet>> GetPlanet()
        {
            try
            {
                _logger.LogInformation("GetItems called");
                return await _context.Planets.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
         
        }

        public async Task<Planet> UpsertPlanet(Planet planet)
        {
            _logger.LogInformation("UpsertItem called");

            // Check if the Id is not the default empty ObjectId
            if (planet.Id != ObjectId.Empty)
            {
                var existingPlanet = await _context.Planets.FindAsync(planet.Id);
                if (existingPlanet == null)
                {
                    throw new Exception("Item not found");
                }
                existingPlanet.Name = planet.Name;
                existingPlanet.Mass = planet.Mass;
                _context.Planets.Update(existingPlanet);
            }
            else
            {
                // New planet - generate new Id explicitly (optional, since your class constructor does it)
                planet.Id = ObjectId.GenerateNewId();

                await _context.Planets.AddAsync(planet);
            }

            await _context.SaveChangesAsync();

            return planet;
        }


    }
}
