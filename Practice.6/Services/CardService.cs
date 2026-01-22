using Practice._6.Interfaces;
using Practice._6.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Practice._6.Services
{
    public class CardService : ICardServices
    {
        private readonly string _filePath = "D:/razdel c/Desktop/Practice/Practice.6/Data/Cards.json";


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
            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Card>();

            return JsonSerializer.Deserialize<List<Card>>(json)
                   ?? new List<Card>();
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