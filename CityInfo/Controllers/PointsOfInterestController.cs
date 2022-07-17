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
        public ActionResult<IEnumerable<PointOfInterestDto>> getPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointofinterestid}")]
        public ActionResult<PointOfInterestDto> getPointOfInterest(int cityId, int pointofinterestid)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var interest = city.PointsOfInterest.FirstOrDefault(i => i.Id == pointofinterestid);
            if (interest == null)
            {
                return NotFound();
            }
            return Ok(interest);
        }


    }
}

