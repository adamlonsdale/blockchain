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
        public IList<Transaction> PendingTransactions { get; set; }
        public IList<Block> Blocks { get; set; }
        public Block LatestBlock => Blocks[Blocks.Count - 1];

        public Blockchain()
        {
            PendingTransactions = new List<Transaction>();
            Blocks = new List<Block>();

            // Add genesis block
            var block = new Block() { Index = 0 };
            Blocks.Add(block);
        }

        public Blockchain(IList<Transaction> transactions, IList<Block> blocks)
        {
            PendingTransactions = transactions;
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

            Blocks.Add(block);
            PendingTransactions.Clear();
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
