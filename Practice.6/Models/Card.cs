using System.Text.RegularExpressions;

namespace Practice._6.Models
{
    public class Card
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Bonus { get; set; }
        public string CardNumber { get; set; }
        public Bank bank { get; set; }
        public bool WithDraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        override public string ToString()
        {
            return $"Id: {Id}, CardNumber: {CardNumber}, Balance: {Balance}, Bonus: {Bonus}";
        }
        public static bool IsValidCardNumber(string cardNumber)
        {
            return Regex.IsMatch(cardNumber, @"^\d{16}$");
        }

    }
}