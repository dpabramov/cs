using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CitiesDataStore.Core;
using _22_WebApplication1.Models;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace _22_WebApplication1.Controllers
{
    public class CitiesController : Controller
    {
        private ICitiesDataStore _dataStore;

        //логирование
        private ILogger<CitiesController> _logger;

        public CitiesController(ICitiesDataStore dataStore,
                                ILogger<CitiesController> logger)
        {
            _dataStore = dataStore;
            _logger = logger;
        }

        [HttpGet("/api/cities")]
        public IActionResult GetCities()
        {
            try
            {
                List<CityGetModel> cityGetModelList = _dataStore
                                        .GetCity()
                                        .Select(x => new CityGetModel(x))
                                        .ToList();

                string jsonString = JsonConvert.SerializeObject(cityGetModelList);

                _logger.LogInformation($"Method GetCities. Returned List of CityGetModel: {jsonString}");

                return Ok(cityGetModelList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method GetCities. Error happend");
                throw;
            }
        }

        [HttpGet("/api/cities/{id}")]
        public IActionResult GetCities(int id)
        {
            City city = _dataStore.GetCity(id);

            if (city != null)
            {
                string jsonString = JsonConvert.SerializeObject(city);
                _logger.LogInformation($"Method GetCities. Return CityGetModel: {jsonString}");

                return Ok(new CityGetModel(city));
            }

            _logger.LogInformation($"Method GetCities. City not found by id = {id}");
            return NotFound();
        }

        [HttpPost("/api/cities")]
        public IActionResult AddCity([FromBody]CityCreateModel cityCreateModel)
        {
            if (cityCreateModel == null)
            {
                _logger.LogInformation("Method AddCity. Parameter cityCreateModel is null");

                return BadRequest();
            }


            //if (cityCreateModel.Name == cityCreateModel.Description)
            //    ModelState.AddModelError("Description", "Fields Name and description must be diffrent");

            if (!ModelState.IsValid)
            {
                _logger.LogError($"Method AddCity. Uncorrect parameter cityCreateModel: " +
                                $"{JsonConvert.SerializeObject(cityCreateModel)}");

                return BadRequest(ModelState);
            }


            int id = _dataStore.AddCity(cityCreateModel.Name,
                                    cityCreateModel.Description,
                                    cityCreateModel.NumberOfPointsOfInterest);

            var result = new CityGetModel(_dataStore.GetCity(id));

            _logger.LogInformation($"Method AddCity. City Added correctly: " +
                                $"{JsonConvert.SerializeObject(result)}");

            return Created($"/api/cities/{id}", result);
        }

        [HttpPut("/api/cities/{id}")]
        public IActionResult UpdateCity(int id, [FromBody]CityCreateModel newCity)
        {
            if (newCity == null)
            {
                _logger.LogInformation("Method UpdateCity. Parameter newCity is null");
                return BadRequest();
            }
                
            //if (cityCreateModel.Name == cityCreateModel.Description)
            //    ModelState.AddModelError("Description", "Fields Name and description must be diffrent");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Method UpdateCity. Uncorrect parameter newCity");
                return BadRequest(ModelState);
            }
                

            City city = _dataStore.UpdateCity(id, newCity.Name, newCity.Description, newCity.NumberOfPointsOfInterest);

            if (city != null)
            {
                _logger.LogInformation($"Method UpdateCity. City updated succesfuly" +
                                    $"{JsonConvert.SerializeObject(city)}");

                return Ok(new CityGetModel(_dataStore.GetCity(id)));
            }

            _logger.LogInformation($"Method UpdateCity. Not Found City by id = {id}");

            return NotFound();
        }

        [HttpDelete("/api/cities/{id}")]
        public IActionResult DeleteCity(int id)
        {
            if (_dataStore.DeleteCity(id))
            {
                _logger.LogInformation($"Method DeleteCity. City id = {id} deleted.");
 
                return NoContent();
            }

            _logger.LogInformation($"Method DeleteCity. Not found City by id = {id}.");
            return NotFound();
        }
    }
}
