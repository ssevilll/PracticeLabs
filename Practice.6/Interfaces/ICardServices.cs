using Practice._6.Models;

namespace Practice._6.Interfaces
{
    public interface ICardServices
    {
        List<Card> GetAllCards();
        void AddCard(Card card);
        Card this[string CardNumber] { get; }
    }
}
