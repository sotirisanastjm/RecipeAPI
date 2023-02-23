using RecipeAPI.Models.DTO;

namespace RecipeAPI.Data
{
    public class RecipeStore
    {
        public static List<RecipeDTO> recipeList= new List<RecipeDTO>
            {
                new RecipeDTO {Id=1,Name="Spaghetti Alfredo",Description="Spaghetti with Chicken",Ingredients="Pasta,Chicken"},
                new RecipeDTO {Id=2,Name="Spaghetti Napoletana",Description="Spaghetti with Mediterenean flavors",Ingredients="Pasta,Tomatoes,Basil"}
            };
    }
}
