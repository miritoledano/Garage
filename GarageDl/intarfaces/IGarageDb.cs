using GarageEntities;
using System.Collections.Generic;

namespace GarageDl.intarfaces
{
    public interface IGarageDb
    {
        void AddGarage(Garage garage);      // מקבל DTO
        List<Garage> GetAllGarages();               // מחזיר Entity
        List<Garage> FetchAndSaveFromApi();         // מחזיר Entity        // מחזיר Entity
    }
}
