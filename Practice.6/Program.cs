using Practice._6.Models;
using Practice._6.Services;

namespace Practice._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardService cardService = new();
            TransactionService transactionService = new();

            Card card = new()
            {
                Id = 1,
                CardNumber = "1234567812345678",
                Balance = 1000,
                bank = Bank.Kapital
            };
            Card card2 = new()
            {
                Id = 2,
                CardNumber = "8765432187654321",
                Balance = 2000,
                bank = Bank.ABB
            };

            //cardService.AddCard(card);
            //cardService.AddCard(card2);
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            Card card3 = new Card()
            {
                Id = 3,
                CardNumber = "1111222233334444",
                Balance = 500,
                bank = Bank.Leo
            };

            cardService.AddCard(card3);

            Card card4 = new Card()
            {
                Id = 4,
                CardNumber = "4444333322221111",
                Balance = 1500,
                bank = Bank.Kapital
            };

            //cardService.AddCard(card4);
            var cards = cardService.GetAllCards();
            foreach (var c in cards)
            {
                Console.WriteLine(c);
            }
        }
    }
}
