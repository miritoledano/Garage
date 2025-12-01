using AutoMapper;
using GarageDB.EF.Models;
using GarageEntities;

namespace GarageApi
{
    public class MapperManager : Profile
    {
        public MapperManager()
        {

            CreateMap<AddGarageDto, Garage>();


        }
    }
}
