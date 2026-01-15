namespace Practice._5.Models
{
    public class Pizza : Food
    {
        public double Radius { get; set; }
        public bool IsSpicy { get; set; }
        public override double CalcPrice()
        {
            double area = (Math.PI * Radius * Radius);
            double basePrice = area * 0.1; // Base price per square unit
            if (IsSpicy)
            {
                basePrice += 1.15; // Extra charge for spicy pizzas
            }
            return basePrice;
        }
        override public string ToString()
        {
            return $"Pizza: {Name}, Radius: {Radius}cm, IsSpicy: {IsSpicy}, Price: {CalcPrice():C}";
        }
    }
}
