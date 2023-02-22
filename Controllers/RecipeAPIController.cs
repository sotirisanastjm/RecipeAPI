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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RecipeDTO>> GetRecipes()
        {
            return Ok(RecipeStore.recipeList);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RecipeDTO> GetRecipe(int id)
        {
            if(id== 0)
            {
                return BadRequest();
            }
            var recipe = RecipeStore.recipeList.FirstOrDefault(u=>u.Id== id);
            if(recipe== null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
    }
}
