using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> getPointsOfInterest(int cityID)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityID);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }


    }
}

