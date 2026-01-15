using Practice._5.Models;

namespace Practice._5.Services
{
    public class PizzaService : IPizzaService
    {
        public Pizza LargestPizza(Pizza[] pizzas)
        {
            return pizzas.OrderByDescending(p => p.Radius).FirstOrDefault();
        }
    }
}
