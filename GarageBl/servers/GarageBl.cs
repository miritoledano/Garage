using AutoMapper;
using GarageBl.intarfaces;
using GarageDl.intarfaces;
using GarageEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageBl.servers
{
   
        public class GarageBl 
        {
            private readonly IGarageDb _garageDl;
         private readonly IMapper _mapper;


        //public GarageBl(IGarageDl garageDl, IMapper mapper)
        //{
        //    _garageDl = garageDl;
        //    _mapper = mapper;
        //}
        public GarageBl(IGarageDb garageDl, IMapper mapper)
        {
            _garageDl = garageDl;
            _mapper = mapper;
        }
        //public void AddGarage(AddGarageDto garageDto)
        //    {
        //        Garage garageMapper = _mapper.Map<Garage>(garageDto);
        //        _garageDl.AddGarage(garageMapper);
        //    }

        //    public List<Garage> GetAllGarages()
        //    {
        //        return _garageDl.GetAllGarages();
        //    }

        //    public List<Garage> FetchAndSaveFromApi()
        //    {
        //        // כאן תוסיף את הלוגיקה שלך למשיכת נתונים מה-API ושמירתם ב-DL
        //        var garagesFromApi = _garageDl.FetchFromApi(); // DL אחראי על החיבור ל-API
        //        foreach (var garage in garagesFromApi)
        //        {
        //            _garageDl.AddGarage(garage);
        //        }
        //        return garagesFromApi;
        //    }
        }
    }

