namespace Practice._6.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"CardNumber: {CardNumber}, Amount: {Amount}";
        }
    }
}
