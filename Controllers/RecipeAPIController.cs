using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Models.DTO;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [Route("api/RecipeAPI")]
    [ApiController]
    public class RecipeAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RecipeDTO> GetRecipes()
        {
            return new List<RecipeDTO>
            {
                new RecipeDTO {Id=1,Name="Spaghetti Alfredo"},
                new RecipeDTO {Id=2,Name="Spaghetti Napolitan"}
            };
        }
    }
}
