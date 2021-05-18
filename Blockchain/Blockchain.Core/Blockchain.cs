using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    public class Blockchain
    {
        private TransactionManager transactionManager;

        public IList<Transaction> PendingTransactions => transactionManager.GetPendingTransactions();
        public IList<Block> Blocks { get; set; }
        public Block LatestBlock => Blocks[Blocks.Count - 1];

        public Blockchain()
        {
            this.transactionManager = new TransactionManager();
            Blocks = new List<Block>();

            // Add genesis block
            var block = new Block() { Index = 0 };

            var tran = new Transaction();
            tran.Outputs.Add(new TransactionOutput() { Address = new Address(), Amount = 1000000 });

            block.Transactions.Add(tran);
            Blocks.Add(block);
        }

        public Blockchain(IList<Transaction> transactions, IList<Block> blocks)
        {
            this.transactionManager = new TransactionManager();
            this.transactionManager.AddPendingTransactions(transactions);

            Blocks = blocks;
        }

        public void AddBlock(Block block)
        {
            if (block.Index != LatestBlock.Index + 1)
                throw new BlockIndexException();

            if (string.IsNullOrEmpty(block.ParentHash))
                throw new BlockParentHashException();

            if (block.Hash != Block.CreateHash(block))
                throw new HashNotEqualException();

            foreach (var transaction in block.Transactions)
                this.transactionManager.RemovePendingTransaction(transaction);

            Blocks.Add(block);
        }

        public Block GetBlock(int index)
        {
            return Blocks[index];
        }

        public Block GetBlock(string hash)
        {
            for(int i = 0; i < Blocks.Count; i++)
            {
                if (Blocks[i].Hash == hash)
                    return Blocks[i];
            }

            return null;
        }
    }
}
