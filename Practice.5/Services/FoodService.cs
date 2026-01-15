using Practice._5.Models;

namespace Practice._5.Services
{
    public class FoodService : IFoodService
    {
        public DateTime WhenWillPrepared(Food food)
        {
            return food.CreationDate+food.PreparationTime;
        }
        public int CountOfFoodsWithMoreThanCalories(Food[] foods, int calories)
        {
            return foods.Count(food => food.Calories > calories);
        }
    }
}
