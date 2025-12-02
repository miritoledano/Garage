
using GarageBL.intarfaces;
using GarageBL.servers;
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
        private readonly IGaradeBll _garageBll;

        public GaragesController(IGaradeBll garageBll)
        {
            _garageBll = garageBll;
        }

        // POST: api/garages/AddGarage
        [HttpPost]
        public IActionResult AddGarageAsync(AddGarageDto garageDto)
        {
            try
            {
                _garageBll.AddGarageAsync(garageDto);
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
                List<Garage> garages = _garageBll.GetAllGarages();
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
                List<Garage> garages = await _garageBll.FetchAndSaveFromApiAsync();
                return Ok(garages);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddSelectedGarages([FromBody] List<Garage> selectedGarages)
        {
            await _garageBll.AddSelectedGaragesAsync(selectedGarages);
            return Ok();
        }

    }
}
