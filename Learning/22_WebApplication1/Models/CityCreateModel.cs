using CitiesDataStore.Core;
using System.ComponentModel.DataAnnotations;

namespace _22_WebApplication1.Models
{
    public class CityCreateModel
    {
        [Required(ErrorMessage ="Поле Name является обязательным")]
        [MaxLength(100)]
        public string Name;

        [MaxLength(255)]
        public string Description;

        [Range(0, 100)]
        public int NumberOfPointsOfInterest;

        public City ConvertToCity(int id)
        {
            return new City
            {
                Id = id,
                Name = Name,
                Description = Description,
                NumberOfPointsOfInterest = NumberOfPointsOfInterest
            };
        }
    }
}
