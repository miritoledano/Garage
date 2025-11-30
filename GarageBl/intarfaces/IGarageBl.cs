using GarageEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageBl.intarfaces
{
    public interface IGarageBl
    {
        void AddGarage(AddGarageDto garageDto);
        List<Garage> GetAllGarages();
        List<Garage> FetchAndSaveFromApi(); // פעולה למשיכת נתונים מה-API
    }
}
