using Blockchain.Core;
using System;
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

            var transaction = new Transaction() { FromAddress = client1, ToAddress = client2, Value = 100 };

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
            System.Console.ReadLine();

            System.Diagnostics.Debugger.Break();
        }
    }
}
