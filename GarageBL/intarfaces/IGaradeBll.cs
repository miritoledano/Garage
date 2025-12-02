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
        Task AddGarageAsync(AddGarageDto garageDto);       // ✔ Task במקום void
        List<Garage> GetAllGarages();
        Task<List<Garage>> FetchAndSaveFromApiAsync();
        Task AddSelectedGaragesAsync(List<Garage> selectedGarages);

    }
}
