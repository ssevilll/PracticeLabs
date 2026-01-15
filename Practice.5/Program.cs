using Practice._5.Models;
using Practice._5.Services;

namespace Practice._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza
            {
                Name = "Pepperoni",
                Radius = 12.5,
                Calories = 800,
                IsSpicy = false,
                PreparationTime = new(0, 4, 26),
                CreationDate = DateTime.Now,
            };

            IFoodService foodService = new FoodService();
            DateTime readyTime = foodService.WhenWillPrepared(pizza);
            Console.WriteLine($"The pizza will be ready at: {readyTime}");


            Pizza[] pizzas = new Pizza[5]
            {
                new() { Name = "Margherita", Radius = 12, Calories = 250, IsSpicy = false, PreparationTime = TimeSpan.FromMinutes(15), CreationDate = DateTime.Now },
                new() { Name = "Pepperoni", Radius = 14, Calories = 320, IsSpicy = true, PreparationTime = TimeSpan.FromMinutes(18), CreationDate = DateTime.Now },
                new() { Name = "BBQ Chicken", Radius = 16, Calories = 400, IsSpicy = true, PreparationTime = TimeSpan.FromMinutes(20), CreationDate = DateTime.Now },
                new() { Name = "Veggie", Radius = 10, Calories = 220, IsSpicy = false, PreparationTime = TimeSpan.FromMinutes(12), CreationDate = DateTime.Now },
                new Pizza { Name = "Hawaiian", Radius = 13, Calories = 280, IsSpicy = false, PreparationTime = TimeSpan.FromMinutes(17), CreationDate = DateTime.Now }
            };

            int count = foodService.CountOfFoodsWithMoreThanCalories(pizzas, 300);
            Console.WriteLine($"Number of pizzas with more than 300 calories: {count}");

            IPizzaService pizzaService = new PizzaService();
            Pizza largestPizza = pizzaService.LargestPizza(pizzas);
            Console.WriteLine($"The largest pizza is: {largestPizza}");
        }
    }
}
