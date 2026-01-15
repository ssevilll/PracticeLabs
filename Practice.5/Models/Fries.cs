namespace Practice._5.Models
{
    public class Fries : Food
    {
        public bool IsSalty { get; set; }
        public double WeightInGrams { get; set; }
        public override double CalcPrice()
        {
            double basePrice = WeightInGrams * 1; // Base price per gram
            if (IsSalty)
            {
                basePrice += 0.80; // Extra charge for salty fries
            }
            return basePrice;
        }
        override public string ToString()
        {
            return $"Fries: {Name}, Weight: {WeightInGrams}g, IsSalty: {IsSalty}, Price: {CalcPrice():C}";
        }
    }
}
