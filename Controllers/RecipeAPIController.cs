using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Models.DTO;
using RecipeAPI.Models;
using RecipeAPI.Data;

namespace RecipeAPI.Controllers
{
    [Route("api/RecipeAPI")]
    [ApiController]
    public class RecipeAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RecipeDTO> GetRecipes()
        {
            return RecipeStore.recipeList;
        }
    }
}
