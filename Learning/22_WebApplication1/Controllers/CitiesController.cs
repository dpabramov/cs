using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _22_WebApplication1.Storage;
using _22_WebApplication1.Models;
using System.Linq;

namespace _22_WebApplication1.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet("/api/cities")]
        public IActionResult GetCities()
        {
            DataStore datastore = DataStore.GetInstance();
            var cities = datastore.Cities;

            return Ok(cities);
        }

        [HttpGet("/api/cities/{id}")]
        public IActionResult GetCities(int id)
        {
            City result = DataStore
                .GetInstance()
                .Cities
                .FirstOrDefault(c => c.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("/api/cities")]
        public IActionResult AddCity([FromBody]City city)
        {
            DataStore datastore = DataStore.GetInstance();
            datastore.Cities.Add(city);

            return Created("/api/cities/" + city.Id, city);
        }

        [HttpPut("/api/cities/{id}")]
        public IActionResult UpdateCity(int id, [FromBody]City newCity)
        {
            DataStore datastore = DataStore.GetInstance();

            City city = datastore.Cities.FirstOrDefault(param => param.Id == id);

            int Index = datastore.Cities.IndexOf(city);

            datastore.Cities[Index].Name = newCity.Name;
            datastore.Cities[Index].Description = newCity.Description;
            datastore.Cities[Index].NumberOfPointsOfInterest = newCity.NumberOfPointsOfInterest;

            return Ok(datastore.Cities[Index]);
        }

        [HttpDelete("/api/cities/{id}")]
        public IActionResult DeleteCity(int id)
        {
            DataStore datastore = DataStore.GetInstance();

            City city = datastore.Cities.FirstOrDefault(param => param.Id == id);

            if (city ==null)
                return NotFound();

            datastore.Cities.Remove(city);

            return Ok();
        }
    }
}
