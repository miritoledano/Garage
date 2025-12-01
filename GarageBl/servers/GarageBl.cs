using AutoMapper;
using GarageBL.intarfaces;
using GarageDB.EF.Models;
using GarageDB.intarfaces;
using GarageEntities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarageBL.servers
{
    public class GarageBl : IGarageBl
    {
        private readonly IGarageDb _garageDb;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public GarageBl(IGarageDb garageDb, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _garageDb = garageDb;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public void AddGarage(AddGarageDto garageDto)
        {
            var garageEntity = _mapper.Map<Garage>(garageDto);
            _garageDb.AddGarage(garageEntity);
        }

        public List<Garage> GetAllGarages()
        {
            return _garageDb.GetAllGarages();
        }

        public async Task<List<Garage>> FetchAndSaveFromApiAsync()
        {
            const string apiUrl =
                "https://data.gov.il/api/3/action/datastore_search?resource_id=bb68386a-a331-4bbc-b668-bba2766d517d&limit=1000";

            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(60);

            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(content);

            var records = jsonDoc.RootElement
                .GetProperty("result")
                .GetProperty("records");

            var garagesFromApi = new List<Garage>();

            foreach (var record in records.EnumerateArray())
            {
                // --- קריאת שדות מה־API ---
                string misparStr = record.TryGetProperty("מספר מוסך", out var misparProp)
                    ? misparProp.GetString() ?? "0"
                    : "0";

                string shemMosah = record.TryGetProperty("שם מוסך", out var shemProp)
                    ? shemProp.GetString() ?? string.Empty
                    : string.Empty;

                string codSugStr = record.TryGetProperty("קוד סוג מוסך", out var codSugProp)
                    ? codSugProp.GetString() ?? "0"
                    : "0";

                string sugMosah = record.TryGetProperty("סוג מוסך", out var sugProp)
                    ? sugProp.GetString() ?? string.Empty
                    : string.Empty;

                string ktovet = record.TryGetProperty("כתובת", out var ktovetProp)
                    ? ktovetProp.GetString()
                    : null;

                string yishuv = record.TryGetProperty("ישוב", out var yishuvProp)
                    ? yishuvProp.GetString()
                    : null;

                string telephone = record.TryGetProperty("טלפון", out var telProp)
                    ? telProp.GetString()
                    : null;

                string mikudStr = record.TryGetProperty("מיקוד", out var mikudProp)
                    ? mikudProp.GetString() ?? "0"
                    : "0";

                string codMiktzoaStr = record.TryGetProperty("קוד מקצוע", out var codMiktzoaProp)
                    ? codMiktzoaProp.GetString() ?? "0"
                    : "0";

                string miktzoa = record.TryGetProperty("מקצוע", out var miktzoaProp)
                    ? miktzoaProp.GetString()
                    : null;

                string menahelMiktzoa = record.TryGetProperty("מנהל מקצוע", out var menahelProp)
                    ? menahelProp.GetString()
                    : null;

                string rashamStr = record.TryGetProperty("רשם חברות", out var rashamProp)
                    ? rashamProp.GetString() ?? "0"
                    : "0";

                string testime = record.TryGetProperty("תת-סוג", out var testimeProp)
                    ? testimeProp.GetString()
                    : null;

                // --- המרת מספרים ---
                int.TryParse(misparStr, out int misparMosah);
                int.TryParse(codSugStr, out int codSugMosah);
                int.TryParse(mikudStr, out int mikud);
                int.TryParse(codMiktzoaStr, out int codMiktzoa);
                long.TryParse(rashamStr, out long rashamHavarot);

                // --- יצירת אובייקט Garage ---
                var garage = new Garage
                {
                    MisparMosah = misparMosah,
                    ShemMosah = shemMosah,
                    CodSugMosah = codSugMosah,
                    SugMosah = sugMosah,
                    Ktovet = ktovet,
                    Yishuv = yishuv,
                    Telephone = telephone,
                    Mikud = mikud,
                    CodMiktzoa = codMiktzoa,
                    Miktzoa = miktzoa,
                    MenahelMiktzoa = menahelMiktzoa,
                    RashamHavarot = rashamHavarot,
                    Testime = testime
                };

                garagesFromApi.Add(garage);

                try
                {
                    _garageDb.AddGarage(garage);
                }
                catch (InvalidOperationException)
                {
                    // כבר קיים - לא עושים כלום
                }
            }

            return garagesFromApi;
        }
    }
}
