
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
        private readonly ILogger<GaragesController> _logger;


        public GaragesController(IGaradeBll garageBll, ILogger<GaragesController> logger)
        {
            _garageBll = garageBll;
            _logger = logger;
        }

        // POST: api/garages/AddGarage
        [HttpPost]
        public async Task<IActionResult> AddGarageAsync(AddGarageDto garageDto)
        {
            try
            {
                await _garageBll.AddGarageAsync(garageDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error on AddGarageAsync, Message: {ex.Message}," +
                                   $" InnerException: {ex.InnerException}, StackTrace: {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
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
                _logger.LogError($"Error on GetAllGarages, Message: {ex.Message}," +
                                                  $" InnerException: {ex.InnerException}, StackTrace: {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
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
                _logger.LogError($"Error on FetchAndSaveFromApi, Message: {ex.Message}," +
                                                                 $" InnerException: {ex.InnerException}, StackTrace: {ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]

        public async Task<ActionResult> AddSelectedGarages([FromBody] List<Garage> selectedGarages)
        {
            try
            {
                await _garageBll.AddSelectedGaragesAsync(selectedGarages);
                return Ok(new { message = "Selected garages added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding selected garages");
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new { message = "Error adding selected garages" });
            }
        }


    }
}
