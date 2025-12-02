using AutoMapper;
using GarageBL.intarfaces;
using GarageDB.EF.Models;
using GarageDB.intarfaces;
using GarageDB.servers;
using GarageEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarageBL.servers
{
    public class GaradeBll : IGaradeBll
    {
        private readonly IGarageDb _garageDb;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public GaradeBll(IGarageDb garageDb, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _garageDb = garageDb;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        // הוספת מוסך אחד (מהטופס או מ-Multi-Select)
        public async Task AddGarageAsync(AddGarageDto garageDto)
        {
            var garageEntity = _mapper.Map<Garage>(garageDto);
            await _garageDb.AddGarageAsync(garageEntity);
        }

        // קבלת כל המוסכים ב-DB
        public List<Garage> GetAllGarages()
        {
            return _garageDb.GetAllGarages();
        }

        // שליפת כל המוסכים מה-API (בלי שמירה)
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
            var records = jsonDoc.RootElement.GetProperty("result").GetProperty("records");

            var garagesFromApi = new List<Garage>();

            foreach (var record in records.EnumerateArray())
            {
                try
                {
                    var garage = new Garage
                    {
                        MisparMosah = record.TryGetProperty("mispar_mosah", out var mProp) ? mProp.GetInt32() : 0,
                        ShemMosah = record.TryGetProperty("shem_mosah", out var sProp) ? sProp.GetString() : null,
                        CodSugMosah = record.TryGetProperty("cod_sug_mosah", out var csProp) ? csProp.GetInt32() : 0,
                        SugMosah = record.TryGetProperty("sug_mosah", out var sgProp) ? sgProp.GetString() : null,
                        Ktovet = record.TryGetProperty("ktovet", out var kProp) ? kProp.GetString() : null,
                        Yishuv = record.TryGetProperty("yishuv", out var yProp) ? yProp.GetString() : null,
                        Telephone = record.TryGetProperty("telephone", out var tProp) ? tProp.GetString() : null,
                        Mikud = record.TryGetProperty("mikud", out var mikProp) ? mikProp.GetInt32() : 0,
                        CodMiktzoa = record.TryGetProperty("cod_miktzoa", out var cmProp) ? cmProp.GetInt32() : 0,
                        Miktzoa = record.TryGetProperty("miktzoa", out var miProp) ? miProp.GetString() : null,
                        MenahelMiktzoa = record.TryGetProperty("menahel_miktzoa", out var mmProp) ? mmProp.GetString() : null,
                        RashamHavarot = record.TryGetProperty("rasham_havarot", out var rProp) ? rProp.GetInt64() : 0,
                        Testime = record.TryGetProperty("TESTIME", out var ttProp) ? ttProp.GetString() : null
                    };

                    garagesFromApi.Add(garage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to parse garage: {ex.Message}");
                }
            }

            return garagesFromApi;
        }

        // הוספת רשימת מוסכים שנבחרו ל-DB
        public async Task AddSelectedGaragesAsync(List<Garage> selectedGarages)
        {
            foreach (var garage in selectedGarages)
            {
                var exists = _garageDb.GetAllGarages().Any(g => g.MisparMosah == garage.MisparMosah);
                if (!exists)
                {
                    await _garageDb.AddGarageAsync(garage);
                }
            }
        }
    }
}
