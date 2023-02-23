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
        [HttpGet("{id:int}",Name ="GetRecipe")]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RecipeDTO> CreateRecipe([FromBody]RecipeDTO recipeDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (RecipeStore.recipeList.FirstOrDefault(u => u.Name.ToLower() == recipeDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom Error", "Recipe already Exists!");
                return BadRequest(ModelState);
            }
            if(recipeDTO == null)
            {
                return BadRequest(recipeDTO);

            }
            if(recipeDTO.Id> 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            recipeDTO.Id=RecipeStore.recipeList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            RecipeStore.recipeList.Add(recipeDTO);
            return CreatedAtRoute("GetRecipe", new {id=recipeDTO.Id},recipeDTO);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}",Name ="DeleteRecipe")]
        public IActionResult DeleteRecipe(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var recipe = RecipeStore.recipeList.FirstOrDefault(u=>u.Id==id);
            if (recipe == null) 
            {
                return NotFound();
            }
            RecipeStore.recipeList.Remove(recipe);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int",Name ="UpdateRecipe")]
        public IActionResult UpdateRecipe(int id, [FromBody]RecipeDTO recipeDTO) 
        {
            if(recipeDTO==null || id!=recipeDTO.Id)
            {
                return BadRequest();
            }
            var recipe=RecipeStore.recipeList.FirstOrDefault(u=>u.Id== id);
            recipe.Name = recipeDTO.Name;
            recipe.Description = recipeDTO.Description;
            recipe.Ingredients = recipeDTO.Ingredients;
            return NoContent();
        }

        
    }
}
