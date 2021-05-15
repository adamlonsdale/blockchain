using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    public class Transaction
    {
        public Address FromAddress { get; set; }
        public Address ToAddress { get; set; }
        public decimal Value { get; set; }
        public byte[] Payload { get; set; }

        public string Hash => CalculateHash();

        private string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string data = $"{FromAddress}{ToAddress}{Value}{Encoding.Default.GetString(Payload)}";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Utils.ByteArrayToString(bytes);
            }
        }
    }
}
