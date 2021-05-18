using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    public class Block
    {
        public Block()
        {
            Transactions = new List<Transaction>();
            Hash = CreateHash(this);
        }

        [JsonPropertyName("i")]
        public int Index { get; set; }

        [JsonPropertyName("txs")]
        public IList<Transaction> Transactions { get; set; }
        
        [JsonPropertyName("h")]
        public string Hash { get; set; }
        
        [JsonPropertyName("ph")]
        public string ParentHash { get; set; }

        [JsonPropertyName("t")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("n")]
        public int Nonce { get; set; }

        public static string CreateHash(Block block)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = $"{block.ParentHash}{block.Timestamp}{FindMerkleRootHash(block.Transactions)}{block.Nonce}";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Utils.ByteArrayToString(bytes);
            }
        }

        private static string FindMerkleRootHash(IList<Transaction> transactionList)
        {
            var transactionStrList = transactionList.Select(tran => Utils.CalculateHash(tran.Hash)).ToList();
            return BuildMerkleRootHash(transactionStrList);
        }

        private static string BuildMerkleRootHash(IList<string> merkelLeaves)
        {
            if (merkelLeaves == null || !merkelLeaves.Any())
                return string.Empty;

            if (merkelLeaves.Count() == 1)
                return merkelLeaves.First();

            if (merkelLeaves.Count() % 2 > 0)
                merkelLeaves.Add(merkelLeaves.Last());

            var merkleBranches = new List<string>();

            for (int i = 0; i < merkelLeaves.Count(); i += 2)
            {
                var leafPair = string.Concat(merkelLeaves[i], merkelLeaves[i + 1]);
                merkleBranches.Add(Utils.CalculateHash(Utils.CalculateHash(leafPair)));
            }
            return BuildMerkleRootHash(merkleBranches);
        }
    }
}
