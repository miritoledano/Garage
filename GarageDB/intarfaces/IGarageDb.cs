using GarageDB.EF.Models;
using System.Collections.Generic;

namespace GarageDB.intarfaces
{
    public interface IGarageDb
    {
        Task AddGarageAsync(Garage garage);
        List<Garage> GetAllGarages();
        //List<Garage> FetchAndSaveFromApi();
        //בוספת הפונקציה הזאת שתוסיף ל DB לפי ה Multi Select
        Task AddSelectedGaragesAsync(List<Garage> selectedGarages);




    }
}



