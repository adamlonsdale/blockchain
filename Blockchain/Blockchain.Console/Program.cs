using Blockchain.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blockchain.Console
{
    class Program
    {
        static void Main(string[] args)
       {
            var chain = new Core.Blockchain();

            var client1 = new Address();
            var client2 = new Address();

            var transaction = new Transaction()
            {
                Inputs = new List<TransactionInput> 
                { 
                    new TransactionInput() { Address = client1, Amount = 1000 } 
                },
                Outputs = new List<TransactionOutput> 
                { 
                    new TransactionOutput() { Address = client2, Amount = 400 }, 
                    new TransactionOutput() { Address = client1, Amount = 600 } // UTXO
                },
                 Timestamp = DateTime.Now
            };

            chain.PendingTransactions.Add(transaction);

            var block = new Block();
            block.Index = chain.LatestBlock.Index + 1;
            foreach (var tx in chain.PendingTransactions)
                block.Transactions.Add(tx);

            block.ParentHash = chain.LatestBlock.Hash;
            
            block.Hash = Block.CreateHash(block);

            chain.AddBlock(block);

            var json = JsonSerializer.Serialize(chain);
            System.Console.WriteLine(json);

            System.Diagnostics.Debugger.Break();
        }
    }
}
