using RecipeAPI.Models.DTO;

namespace RecipeAPI.Data
{
    public class RecipeStore
    {
        public static List<RecipeDTO> recipeList= new List<RecipeDTO>
            {
                new RecipeDTO {Id=1,Name="Spaghetti Alfredo"},
                new RecipeDTO {Id=2,Name="Spaghetti Napolitan"}
            };
    }
}
