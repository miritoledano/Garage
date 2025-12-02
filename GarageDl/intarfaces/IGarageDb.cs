using GarageDB.EF.Models;
using System.Collections.Generic;

namespace GarageDB.intarfaces
{
    public interface IGarageDb
    {
        Task AddGarageAsync(Garage garage);
        List<Garage> GetAllGarages();
        List<Garage> FetchAndSaveFromApi();
         Task AddSelectedGaragesAsync(List<Garage> selectedGarages);




    }
}



