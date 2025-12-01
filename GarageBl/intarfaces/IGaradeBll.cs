using GarageDB.EF.Models;
using GarageEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageBL.intarfaces
{
    public interface IGaradeBll
    {
        void AddGarage(AddGarageDto garageDto);
        List<Garage> GetAllGarages();
        Task<List<Garage>> FetchAndSaveFromApiAsync(); // <-- מתאים למחלקה
    }
}
