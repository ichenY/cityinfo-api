using System;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    // 2. add apicontroller to improve development experiennce, automatically return 400 Bad request, return error detail...
    [ApiController]
    // 4. specify route prefix in the route, can also be api/[controller], it will grab Cities automatically
    [Route("api/cities")]
    // 1. derive from controllerbase
    // controllerbase has a set of built-in helper methods to create IAction result, like OK(), NotFound()...
    public class CitiesController : ControllerBase
    {
        // 3. specify method and route here
        [HttpGet()]
        public ActionResult<CityDto> GetCities()
        {
            //return new JsonResult(
            //    //new List<object> {
            //    //    new { id=1, Name="New York"},
            //    //    new { id=2, Name="LA"}
            //    //}
            //    CitiesDataStore.Current.Cities
            //    );
            var city = CitiesDataStore.Current.Cities;
            return Ok(city);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
    }
}

