using Practice._6.Models;

namespace Practice._6.Interfaces
{
    public interface ITransactionService
    {
        List<Transactions> GetAllTransactions();
        void AddTransaction(Transactions transaction);
        List<Transactions> GetByCardNumber(string cardNumber);
        List<Transactions> GetByDateRange(DateTime startDate, DateTime endDate);
    }
}
