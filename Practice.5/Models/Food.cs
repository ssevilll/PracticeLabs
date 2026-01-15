namespace Practice._5.Models
{
    public abstract class Food
    {
        private DateTime _creationDate;
        private int _calories;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate 
        { 
            get => _creationDate;
            set
            {
                if (value >DateTime.Now)
                {
                    throw new ArgumentException("Creation date cannot be in the future.");
                }
                _creationDate = value;
            } 
        }
        public int Calories 
        { 
            get => _calories; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Calories cannot be negative.");
                }
                _calories = value;
            } 
        }
        public TimeSpan PreparationTime { get; set; }
        public abstract double CalcPrice();
    }
}
