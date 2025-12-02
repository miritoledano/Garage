using GarageDB.EF.Contexts;
using GarageDB.EF.Models;
using GarageDB.intarfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageDB.servers
{
    public class GarageDb : IGarageDb
    {
        private readonly GarageContext _garageContext;

        public GarageDb(GarageContext garageContext)
        {
            _garageContext = garageContext;
        }

        public async Task AddGarageAsync(Garage garage)
        {
            var existingGarage = await _garageContext.Garages
                .FirstOrDefaultAsync(g => g.MisparMosah == garage.MisparMosah);

            if (existingGarage != null)
                throw new InvalidOperationException("Garage with the same MisparMosah already exists.");

            await _garageContext.Garages.AddAsync(garage);
            await _garageContext.SaveChangesAsync();
        }


        public List<Garage> GetAllGarages()
        {
            return _garageContext.Garages.ToList();
        }

        public List<Garage> FetchAndSaveFromApi()
        {
            List<Garage> garagesFromApi = new List<Garage>();
          
            return garagesFromApi;
        }
        public async Task AddSelectedGaragesAsync(List<Garage> selectedGarages)
        {
            foreach (var garage in selectedGarages)
            {
                var exists = await _garageContext.Garages
                    .AnyAsync(g => g.MisparMosah == garage.MisparMosah);

                if (!exists)
                {
                    await _garageContext.Garages.AddAsync(garage);
                }
            }

            await _garageContext.SaveChangesAsync();
        }
    }
}
