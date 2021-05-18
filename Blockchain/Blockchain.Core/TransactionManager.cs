using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    internal class TransactionManager
    {
        private IList<TransactionOutput> unspentTransactionOutputs;
        private IList<Transaction> pendingTransactions;

        public TransactionManager()
        {
            pendingTransactions = new List<Transaction>();
            unspentTransactionOutputs = new List<TransactionOutput>();
        }

        public IList<Transaction> GetPendingTransactions()
        {
            return pendingTransactions;
        }

        public void AddPendingTransaction(Transaction transaction) => pendingTransactions.Add(transaction);
        public void RemovePendingTransaction(Transaction transaction) => pendingTransactions.Remove(transaction);
        public void AddPendingTransactions(IEnumerable<Transaction> transactions)
        {
            foreach (var transaction in transactions)
                pendingTransactions.Add(transaction);
        }

        public void AddUnspentTransaction(TransactionOutput transaction) => unspentTransactionOutputs.Add(transaction);
        public void RemoveUnspentTransaction(TransactionOutput transaction) => unspentTransactionOutputs.Remove(transaction);
        public void AddUnspentTransactions(IEnumerable<TransactionOutput> transactions)
        {
            foreach (var transaction in transactions)
                unspentTransactionOutputs.Add(transaction);
        }

        public IEnumerable<TransactionOutput> GetUnspentTransactionsForAddress(Address address)
        {
            return (from utxo in unspentTransactionOutputs
                    where utxo.Address == address
                    select utxo);
        }
    }
}
