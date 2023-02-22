using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
