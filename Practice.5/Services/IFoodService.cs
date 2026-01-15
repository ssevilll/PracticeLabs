using Practice._5.Models;

namespace Practice._5.Services
{
    public interface IFoodService
    {
        public DateTime WhenWillPrepared(Food food);
        public int CountOfFoodsWithMoreThanCalories(Food[] foods, int calories);
    }
}
