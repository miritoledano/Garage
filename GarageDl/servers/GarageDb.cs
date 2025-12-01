using GarageDB.EF.Contexts;
using GarageDB.EF.Models;
using GarageDB.intarfaces;
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

        public void AddGarage(Garage garage)
        {
            var existingGarage = _garageContext.Garages
                .FirstOrDefault(g => g.MisparMosah == garage.MisparMosah);

            if (existingGarage != null)
                throw new InvalidOperationException("Garage with the same MisparMosah already exists.");

            _garageContext.Garages.Add(garage);
            _garageContext.SaveChanges();
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
    }
}
