using Practice._6.Interfaces;
using Practice._6.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Practice._6.Services
{
    public class CardService : ICardServices
    {

        private readonly string _filePath =
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Cards.json");


        public void AddCard(Card card)
        {
            if (!Card.IsValidCardNumber(card.CardNumber))
            {
                throw new ArgumentException("Invalid card number.");
            }
            var cards = GetAllCards();
            if (cards.Any(c => c.CardNumber == card.CardNumber))
            {
                throw new ArgumentException("Card with this number already exists.");
            }
            cards.Add(card);
            string directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var jsonData = JsonSerializer.Serialize(cards, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }
        public Card this[string CardNumber]
        {
            get
            {
                return GetAllCards().First(c => c.CardNumber == CardNumber);
            }
        }

        public List<Card> GetAllCards()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Card>();
            }
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Card>>(jsonData) ?? new List<Card>();
        }

        public static string MaskCardNumber(Card card)
        {
                return card.CardNumber.Substring(0, 4) + " **** **** " + card.CardNumber.Substring(12, 4); 
        }
        public void ExpenseAndGetBonus(decimal amount,Card card)
        {
            if (card.WithDraw(amount))
            {
                switch (card.bank)
                {
                    case Bank.ABB:
                        card.Bonus += amount * 0.02m;
                        break;
                    case Bank.Kapital:
                        card.Bonus += amount * 0.05m;
                        break;
                    case Bank.Leo:
                        card.Bonus += amount * 0.04m;
                        break;
                }
            }
        }

    }
}