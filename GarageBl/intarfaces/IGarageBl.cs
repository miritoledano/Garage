using GarageDB.EF.Models;
using GarageEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageBL.intarfaces
{
    public interface IGarageBl
    {
        void AddGarage(AddGarageDto garageDto);
        List<Garage> GetAllGarages();
       Task< List<Garage>> FetchAndSaveFromApiAsync(); // <-- מתאים למחלקה
    }
}
