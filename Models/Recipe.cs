using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Execution { get; set; }
        public string ImageURL { get; set; }
    }
}
