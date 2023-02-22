using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Models;

namespace RecipeAPI.Controllers
{
    [ApiController]
    public class RecipeAPIController : ControllerBase
    {
        public IEnumerable<Recipe> GetRecipes()
        {
            return new List<Recipe>
            {
                new Recipe {Id=1,Name="Spaghetti Alfredo"},
                new Recipe {Id=2,Name="Spaghetti Napolitan"}
            };
        }
    }
}
