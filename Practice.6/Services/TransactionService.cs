using Practice._6.Interfaces;
using Practice._6.Models;

namespace Practice._6.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly string _filePath =
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Transactions.json");

        public void AddTransaction(Transactions transaction)
        {
            var transactions = GetAllTransactions();
            transactions.Add(transaction);
            var jsonData = System.Text.Json.JsonSerializer.Serialize(transactions, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }

        public List<Transactions> GetAllTransactions()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Transactions>();
            }
            var jsonData = File.ReadAllText(_filePath);
            return System.Text.Json.JsonSerializer.Deserialize<List<Transactions>>(jsonData) ?? new List<Transactions>();
        }

        public List<Transactions> GetByCardNumber(string cardNumber)
        {
            var transactions = GetAllTransactions();
            return transactions.Where(t => t.CardNumber == cardNumber).ToList();
        }

        public List<Transactions> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetAllTransactions()
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .ToList();
        }
    }
}
