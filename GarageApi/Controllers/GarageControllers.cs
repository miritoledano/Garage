
using GarageBL.intarfaces;
using GarageDB.EF.Models;
using GarageEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogBarberShopApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly IGarageBl _garageBl;

        public GaragesController(IGarageBl garageBl)
        {
            _garageBl = garageBl;
        }

        // POST: api/garages/AddGarage
        [HttpPost]
        public IActionResult AddGarage(AddGarageDto garageDto)
        {
            try
            {
                _garageBl.AddGarage(garageDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/garages/GetAllGarages
        [HttpGet]
        public IActionResult GetAllGarages()
        {
            try
            {
                List<Garage> garages = _garageBl.GetAllGarages();
                return Ok(garages);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/garages/FetchAndSaveFromApi
        [HttpGet]
        public async Task<IActionResult> FetchAndSaveFromApi()
        {
            try
            {
                List<Garage> garages = await _garageBl.FetchAndSaveFromApiAsync();
                return Ok(garages);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
