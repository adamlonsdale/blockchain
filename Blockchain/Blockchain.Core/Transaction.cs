using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    public class Transaction : IEquatable<Transaction>
    {
        public Transaction()
        {
            Inputs = new List<TransactionInput>();
            Outputs = new List<TransactionOutput>();
        }

        [JsonPropertyName("i")]
        public IList<TransactionInput> Inputs { get; set; }

        [JsonPropertyName("o")]
        public IList<TransactionOutput> Outputs { get; set; }

        [JsonPropertyName("p")]
        public byte[] Payload { get; set; }

        [JsonPropertyName("t")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("h")]
        public string Hash => CalculateHash();

        public bool Equals(Transaction other)
        {
            return Hash == other.CalculateHash();
        }

        public override string ToString() => Hash;

        private string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string data = $"{string.Join(",",Inputs)}{string.Join(",", Outputs)}{Timestamp}";
             
                if (Payload != null)
                    data += Utils.ByteArrayToString(Payload);

                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Utils.ByteArrayToString(bytes);
            }
        }
    }
}
