namespace Restraurant.Models
{
    public class DishIngredient
    {
        public Dish? Dish { get; set; }
        public Ingredient? Ingredient { get; set; }
        public int DishId { get; set; }
        public int IngredientId { get; set; }
    }
}
