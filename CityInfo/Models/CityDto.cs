using System;
namespace CityInfo.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int NumberOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }

        // initialize to avoid null reference
        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}

