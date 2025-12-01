using GarageDB.EF.Models;
using System.Collections.Generic;

namespace GarageDB.intarfaces
{
    public interface IGarageDb
    {
        void AddGarage(Garage garage);
        List<Garage> GetAllGarages();
        List<Garage> FetchAndSaveFromApi();
    }
}
