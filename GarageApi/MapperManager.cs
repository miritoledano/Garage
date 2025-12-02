using AutoMapper;
using GarageDB.EF.Models;
using GarageEntities;

namespace GarageApi
{
//העמוד שעושה תמיפוי
    public class MapperManager : Profile
    {
        public MapperManager()
        {

            CreateMap<AddGarageDto, Garage>();


        }
    }
}
